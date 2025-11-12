using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.EntityCreateRequest;
using Entity.Requests.EntityDetailRequest;
using Entity.Requests.EntityUpdateRequest;
using Entity.Requests.ModuleOperation;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces.IModuleOperationRepository;
using Service.Extensions;
using Service.Interfaces.ModelOperationService;
using Utilities.Email.Implement;
using Utilities.Email.Implements;
using Utilities.Email.Interfaces;
using Utilities.Pdf;

namespace Service.Implementations.ModelOperationService
{
    public class EvaluationService : BaseModelService<Evaluation, EvaluationDTO, EvaluationRequest>, IEvaluationService
    {
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly SupabaseStorageService _storage;
        private readonly IEmailEvaluationBrevoService _brevoEmailService;

        public EvaluationService(IEvaluationRepository evaluationRepository, SupabaseStorageService storage, IEmailEvaluationBrevoService brevoEmailService) : base(evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
            _storage = storage;
            _brevoEmailService = brevoEmailService;
        }


        public async Task<EvaluationDetailRequest> CreateEvaluationAsync(EvaluationCreateRequest request)
        {
            var experience = await _evaluationRepository.GetExperienceWithInstitutionAsync(request.ExperienceId)
                ?? throw new KeyNotFoundException("La experiencia no existe");

            var builder = new EvaluationBuilder(request)
                .AddCriteriaScores(request.EvaluationCriteriaDetail);

            var (evaluation, criteriaList) = builder.Build();
            evaluation = await _evaluationRepository.AddEvaluationAsync(evaluation);

            foreach (var c in criteriaList)
            {
                c.EvaluationId = evaluation.Id;
                await _evaluationRepository.AddEvaluationCriteriaAsync(c);
            }

            foreach (var c in request.EvaluationCriteriaDetail)
            {
                var criteria = await _evaluationRepository.GetCriteriaByIdAsync(c.CriteriaId);
                if (criteria != null)
                {
                    await _evaluationRepository.UpdateCriteriaAsync(criteria);
                }
            }

            // ✅ Primero obtenemos todo el detalle completo
            var evaluationDetail = await _evaluationRepository.GetEvaluationDetailAsync(evaluation.Id);

            // ✅ Luego enviamos el correo *después*, sin afectar el contexto de datos
            _ = Task.Run(async () =>
            {
                try
                {
                    if (!string.IsNullOrEmpty(evaluationDetail.Email))
                    {
                        await _brevoEmailService.SendEvaluationResultEmailAsync(
                            evaluationDetail.Email,
                            evaluationDetail.UserName,
                            evaluationDetail.EvaluationResult
                        );
                    }
                }
                catch (Exception ex)
                {
                    // Puedes registrar el error en logs pero no afectar la creación
                    Console.WriteLine($"Error enviando correo: {ex.Message}");
                }
            });

            // ✅ Finalmente retornamos la evaluación como antes (sin afectar los criterios)
            return evaluationDetail;
        }


        public async Task<EvaluationDetailRequest> UpdateEvaluationAsync(int evaluationId, EvaluationUpdateRequest request)
        {
            // 1️⃣ Obtener evaluación con tracking
            var evaluationEntity = await _evaluationRepository.GetEvaluationByIdTrackedAsync(evaluationId);
            if (evaluationEntity == null)
                throw new KeyNotFoundException("No se encontró la evaluación.");

            // 2️⃣ Aplicar los cambios
            evaluationEntity.ApplyPatch(request);

            //  Guardar en base de datos
            await _evaluationRepository.SaveChangesAsync();

            // Retornar la versión actualizada mapeada
            var evaluationDetail = await _evaluationRepository.GetEvaluationDetailAsync(evaluationId);

            // Enviar correo con el resultado actualizado
            if (!string.IsNullOrEmpty(evaluationDetail.Email))
            {
                await _brevoEmailService.SendEvaluationResultEmailAsync(
                    evaluationDetail.Email,
                    evaluationDetail.UserName,
                    evaluationDetail.EvaluationResult
                );
            }

            return evaluationDetail;
        }


        public async Task<string> GenerateAndAttachPdfAsync(int evaluationId)
        {
            var evaluationDto = await _evaluationRepository.GetEvaluationDetailAsync(evaluationId)
                ?? throw new KeyNotFoundException("La evaluación no existe.");
            var logoBytes = await EvaluationPdfGenerator.LoadImageFromUrlAsync(
          "https://clzjdaburaytuimossnf.supabase.co/storage/v1/object/sign/Experiencia-SignificativaPdf/Captura%20de%20pantalla%202025-11-09%20031820.png?token=eyJraWQiOiJzdG9yYWdlLXVybC1zaWduaW5nLWtleV9lMzc5MWUxOC00YmYyLTQ2OWEtYTBlMC04YWVjYzM4MGI5NTIiLCJhbGciOiJIUzI1NiJ9.eyJ1cmwiOiJFeHBlcmllbmNpYS1TaWduaWZpY2F0aXZhUGRmL0NhcHR1cmEgZGUgcGFudGFsbGEgMjAyNS0xMS0wOSAwMzE4MjAucG5nIiwiaWF0IjoxNzYyNzE5NzMwLCJleHAiOjE5NzAwNzk3MzB9.YaqQo3ZuhUciSK6F0_LVusnEPU4NtyTf6d2gp-vF8r8"
          );
            var pdfBytes = EvaluationPdfGenerator.Generate(evaluationDto, logoBytes);

            string pdfUrl = await _storage.UploadEvaluationPdfToSupabase(pdfBytes, evaluationId);
            await _evaluationRepository.UpdateEvaluationPdfUrlAsync(evaluationId, pdfUrl);

            return pdfUrl;
        }



    }
}

