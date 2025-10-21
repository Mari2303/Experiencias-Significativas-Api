﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.ModelosParametro;
using Entity.Models.ModelosParametros;
using Entity.Requests.ModulesParamer;
using Repository.Interfaces.ModuleParamer;
using Service.Interfaces.ModuleParamer;

namespace Service.Implementations.ModuleParamer
{
    public class GradeService : BaseModelService<Grade, GradeDTO, GradeRequest>, IGradeService
    {
        private readonly IGradeRepository _gradeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleService"/> class.
        /// </summary>
        /// <param name="roleRepository">The repository for managing role data.</param>
        public GradeService(IGradeRepository gradeRepository) : base(gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }
    }
    
}
