﻿using AutoMapper;
using Entity.Context;
using Entity.Dtos.ModuleGeographic;
using Entity.Models.ModuleGeographic;
using Entity.Requests.ModuleGeographic;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces.IModuleGeographicRepository;
using Utilities.Helper;

namespace Repository.Implementations.ModuleGeographicRepository
{
    public class MunicipalityRepository : BaseModelRepository<Municipality, MunicipalityDTO, MunicipalityRequest>, IMunicipalityRepository
    {

        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<Municipality, MunicipalityDTO> _helperRepository;
        public MunicipalityRepository(ApplicationContext context, IMapper mapper, IHelper<Municipality, MunicipalityDTO> helperRepository, IConfiguration configuration) : base(context, mapper, configuration, helperRepository)
        {
            _context = context;
            _mapper = mapper;
            _helperRepository = helperRepository;
            _configuration = configuration;
        }
    }
}
