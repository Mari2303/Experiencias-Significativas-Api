﻿
using Entity.Models.ModelosParametros;
using Entity.Models.ModuleOperation;
using Entity.Models;

namespace Entity.Requests.ModuleOperation
{
    public class HistoryExperienceRequest : BaseRequest
    {
        public string Action { get; set; } = string.Empty;
        public string TableName { get; set; } = string.Empty;
     
     
    }
}
