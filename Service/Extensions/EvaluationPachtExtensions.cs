using Entity.Models.ModuleOperation;
using Entity.Requests.EntityUpdateRequest;

namespace Service.Extensions
{
    public static class EvaluationPatchExtensions
    {
        /// <summary>
        /// Aplica los cambios enviados en el request a la evaluación existente
        /// y recalcula el resultado final con base en los nuevos criterios.
        /// </summary>
        public static void ApplyPatch(this Evaluation evaluation, EvaluationUpdateRequest request)
        {
            if (evaluation == null || request == null)
                return;

            // 🔹 Actualizar campos principales
            if (!string.IsNullOrWhiteSpace(request.TypeEvaluation))
                evaluation.TypeEvaluation = request.TypeEvaluation;

            if (!string.IsNullOrWhiteSpace(request.AccompanimentRole))
                evaluation.AccompanimentRole = request.AccompanimentRole;

            if (!string.IsNullOrWhiteSpace(request.Comments))
                evaluation.Comments = request.Comments;

            if (request.ExperienceId > 0)
                evaluation.ExperienceId = request.ExperienceId;

            if (request.UserId > 0)
                evaluation.UserId = request.UserId;

            // 🔹 Actualizar criterios asociados
            if (request.EvaluationCriteriaDetailRequest != null && request.EvaluationCriteriaDetailRequest.Any())
            {
                evaluation.EvaluationCriterias ??= new List<EvaluationCriteria>();

                foreach (var c in request.EvaluationCriteriaDetailRequest)
                {
                    // Buscar criterio existente
                    var existingCriteria = evaluation.EvaluationCriterias
                        .FirstOrDefault(ec => ec.CriteriaId == c.CriteriaId);

                    int totalScore = (c.Scores != null && c.Scores.Any()) ? c.Scores.Sum() : 0;

                    if (existingCriteria != null)
                    {
                        // Actualizar valores
                        existingCriteria.Score = totalScore;
                        if (!string.IsNullOrWhiteSpace(c.DescriptionContribution)) ;
                            
                    }
                    else
                    {
                        // Agregar nuevo criterio
                        evaluation.EvaluationCriterias.Add(new EvaluationCriteria
                        {
                            EvaluationId = evaluation.Id,
                            CriteriaId = c.CriteriaId,
                            Score = totalScore,
                          
                        });
                    }
                }
            }

            // 🔹 Recalcular el resultado final con base en los puntajes
            if (evaluation.EvaluationCriterias != null && evaluation.EvaluationCriterias.Any())
            {
                double averageScore = evaluation.EvaluationCriterias.Average(c => c.Score);

                // Puedes ajustar esta lógica según tu modelo de negocio
                if (averageScore < 50)
                    evaluation.EvaluationResult = "Naciente";
                else if (averageScore < 70)
                    evaluation.EvaluationResult = "Creciente";
                else if (averageScore < 90)
                    evaluation.EvaluationResult = "Inspiradora";
              
            }
        }
    }
}

