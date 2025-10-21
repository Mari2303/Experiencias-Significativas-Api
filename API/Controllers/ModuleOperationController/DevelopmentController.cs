﻿using AutoMapper;
using Entity.Dtos.ModuleOperation;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Service.Interfaces;
using Service.Interfaces.ModelOperationService;

namespace API.Controllers.ModuleOperationController
{
    public class DevelopmentController : BaseModelController<Development, DevelopmentDTO, DevelopmentRequest>
    {
        private readonly IDevelopmentService _developmentService;
        private readonly IMapper _mapper;
        public DevelopmentController(IBaseModelService<Development, DevelopmentDTO, DevelopmentRequest> baseService, IDevelopmentService developmentService, IMapper mapper) : base(baseService, mapper)
        {
            _developmentService = developmentService;
            _mapper = mapper;
        }
    }
}
