﻿

using Entity.Models.ModelosParametros;

namespace Entity.Models.ModuleOperation
{
    public class ExperiencePopulation : BaseModel
    {
        public int ExperienceId { get; set; }
        public int PopulationGradeId { get; set; }
        public virtual Experience Experience { get; set; } = null!;
        public virtual PopulationGrade PopulationGrade { get; set; } = null!;
    }
}
