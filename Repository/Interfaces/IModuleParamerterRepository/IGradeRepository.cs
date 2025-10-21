﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos;
using Entity.Dtos.ModelosParametro;
using Entity.Models;
using Entity.Models.ModelosParametros;
using Entity.Requests;
using Entity.Requests.ModulesParamer;

namespace Repository.Interfaces.ModuleParamer
{
   public interface IGradeRepository : IBaseModelRepository<Grade, GradeDTO, GradeRequest>
    {
    }
}
