﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Requests.ModuleOperation;

namespace Entity.Requests.EntityCreateRequest
{
    public class ObjectiveCreateRequest
    {
        public string DescriptionProblem { get; set; } = string.Empty;
        public string ObjectiveExperience { get; set; } = string.Empty;
        public string EnfoqueExperience { get; set; } = string.Empty;
        public string Methodologias { get; set; } = string.Empty;
        public string InnovationExperience { get; set; } = string.Empty;


        public List<SupportInformationCreateRequest> SupportInformations { get; set; }
        public List<MonitoringCreateRequest> Monitorings { get; set; }
    }
}
