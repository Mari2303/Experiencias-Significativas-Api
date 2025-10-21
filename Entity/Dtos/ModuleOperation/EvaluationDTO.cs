﻿

using System.Text.Json.Serialization;
using Entity.Models;

namespace Entity.Dtos.ModuleOperational
{
    public class EvaluationDTO : GenericDTO
    {
        public string TypeEvaluation { get; set; } = string.Empty;
        public string AccompanimentRole { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public string EvaluationResult { get; set; } = string.Empty;

        public int UserId { get; set; }
        public int ExperienceId { get; set; }
    }
}
