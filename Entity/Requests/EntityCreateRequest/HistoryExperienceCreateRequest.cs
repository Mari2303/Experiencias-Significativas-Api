﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Requests.EntityCreateRequest
{
    public class HistoryExperienceCreateRequest
    {
        public string Action { get; set; } = string.Empty;
        public string TableName { get; set; } = string.Empty;
        public int UserId { get; set; }
       
    }
}
