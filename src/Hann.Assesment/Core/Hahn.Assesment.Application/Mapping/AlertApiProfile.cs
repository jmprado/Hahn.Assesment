using AutoMapper;
using Hahn.Assesment.Domain.AlertApi;
using Hahn.Assesment.Domain.Entities;

namespace Hahn.Assesment.Application.Mapping;

public class AlertApiProfile : Profile
{
    public AlertApiProfile()
    {
        CreateMap<AlertReportApiModel, AlertReport>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MeldungId))
            .ForMember(dest => dest.ExtraAttribute, opt => opt.MapFrom(src => src.ZusatzAttribute))
            .ForMember(dest => dest.AlertId, opt => opt.Ignore())
            .ForMember(dest => dest.Alerts, opt => opt.Ignore());

        CreateMap<AlertCategoryApiModel, AlertCategory>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => src.Auspraegung))
            .ForMember(dest => dest.AlertId, opt => opt.Ignore())
            .ForMember(dest => dest.Alerts, opt => opt.Ignore());

        CreateMap<AlertApiModel, AlertEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.AlertReports, opt => opt.MapFrom(src => src.AlertReports))
            .ForMember(dest => dest.AlertCategories, opt => opt.MapFrom(src => src.AlertCategories));
    }
}
