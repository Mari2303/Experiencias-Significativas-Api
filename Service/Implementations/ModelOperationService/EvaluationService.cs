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
using Utilities.Pdf;

namespace Service.Implementations.ModelOperationService
{
    public class EvaluationService : BaseModelService<Evaluation, EvaluationDTO, EvaluationRequest>, IEvaluationService
    {
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly SupabaseStorageService _storage;

        public EvaluationService(IEvaluationRepository evaluationRepository, SupabaseStorageService storage) : base(evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
            _storage = storage;
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
                    criteria.DescriptionContribution = c.DescriptionContribution;
                    await _evaluationRepository.UpdateCriteriaAsync(criteria);
                }
            }

            return await _evaluationRepository.GetEvaluationDetailAsync(evaluation.Id);
        }

        // -------------------------------
        // UPDATE
        // -------------------------------
        public async Task<EvaluationDetailRequest> UpdateEvaluationAsync(int evaluationId, EvaluationUpdateRequest request)
        {
            // 1️⃣ Obtener entidad desde el repositorio
            var evaluationEntity = await _evaluationRepository.GetById(evaluationId);
            if (evaluationEntity == null)
                throw new KeyNotFoundException("La evaluación no existe.");

            // 2️⃣ Aplicar cambios y recalcular resultado final
            evaluationEntity.ApplyPatch(request);

            // 3️⃣ Guardar cambios
            await _evaluationRepository.Update(evaluationEntity);

            // 4️⃣ Retornar DTO actualizado
            var updated = await _evaluationRepository.GetEvaluationDetailAsync(evaluationId);
            return updated;
        }



        // -------------------------------
        // PDF (flujo separado)
        // -------------------------------
        public async Task<string> GenerateAndAttachPdfAsync(int evaluationId)
        {
            var evaluationDto = await _evaluationRepository.GetEvaluationDetailAsync(evaluationId)
                ?? throw new KeyNotFoundException("La evaluación no existe.");

            var pdfBytes = EvaluationPdfGenerator.Generate(
                TypeEvaluation: evaluationDto.TypeEvaluation,
                comments: evaluationDto.Comments
            );

            string pdfUrl = await _storage.UploadEvaluationPdfToSupabase(pdfBytes, evaluationId);
            await _evaluationRepository.UpdateEvaluationPdfUrlAsync(evaluationId, pdfUrl);

            return pdfUrl;
        }

    }
}

