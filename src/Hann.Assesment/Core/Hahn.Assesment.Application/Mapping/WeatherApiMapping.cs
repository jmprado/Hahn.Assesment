using AutoMapper;
using Hahn.Assesment.Domain.Entities;
using Hahn.Assesment.Domain.SeverityService;

namespace Hahn.Assesment.Application.Mapping;

public class WeatherApiMapping : Profile
{
    public WeatherApiMapping()
    {
        CreateMap<MeldungenModel, SeverityReport>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MeldungId))
            .ForMember(dest => dest.ExtraAttribute, opt => opt.MapFrom(src => src.ZusatzAttribute))
            .ForMember(dest => dest.SeverityAlertId, opt => opt.Ignore())
            .ForMember(dest => dest.SeverityAlert, opt => opt.Ignore());

        CreateMap<HighestSeverityModel, SeverityCategory>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => src.Auspraegung))
            .ForMember(dest => dest.SeverityAlertId, opt => opt.Ignore())
            .ForMember(dest => dest.SeverityAlert, opt => opt.Ignore());

        CreateMap<AlertApiModel, SeverityAlert>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.SeverityReport, opt => opt.MapFrom(src => src.Meldungen))
            .ForMember(dest => dest.SeverityCategories, opt => opt.MapFrom(src => src.HighestSeverities));
    }
}
