using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.EntityDetailRequest;
using Entity.Requests.ModuleOperation;


public class EvaluationProfiles : Profile
{
    public EvaluationProfiles()
    {
        CreateMap<EvaluationDTO, Evaluation>().ReverseMap();
        CreateMap<EvaluationRequest, Evaluation>().ReverseMap();

        // Mapeo principal
        CreateMap<Evaluation, EvaluationDetailRequest>()
            .ForMember(dest => dest.CriteriaEvaluations,
                       opt => opt.MapFrom(src => src.EvaluationCriterias))
            .ForMember(dest => dest.ExperienceName,
                       opt => opt.MapFrom(src => src.Experience.NameExperiences))
            .ForMember(dest => dest.InstitutionName,
                       opt => opt.MapFrom(src => src.Experience.Institution != null
                           ? src.Experience.Institution.Name
                           : string.Empty))
            .ForMember(dest => dest.ThematicLineNames,
                       opt => opt.MapFrom(src => src.Experience.ExperienceLineThematics
                           .Where(x => x.LineThematic != null)
                           .Select(x => x.LineThematic.Name)
                           .ToList()));

        // 🔹 Mapeo del detalle de criterios
        CreateMap<EvaluationCriteria, EvaluationCriteriaRequest>()
            .ForMember(dest => dest.CriteriaId,
                       opt => opt.MapFrom(src => src.Criteria.Id))
            .ForMember(dest => dest.Criteria,
                       opt => opt.MapFrom(src => src.Criteria.Name))
            .ForMember(dest => dest.Score,
                       opt => opt.MapFrom(src => src.Score))
            .ForMember(dest => dest.DescriptionContribution,
                       opt => opt.MapFrom(src => src.DescriptionContribution));
    }
}

