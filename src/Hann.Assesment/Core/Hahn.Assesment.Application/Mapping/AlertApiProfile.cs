using AutoMapper;
using Hahn.Assesment.Domain.AlertApi;
using Hahn.Assesment.Domain.Entities;

namespace Hahn.Assesment.Application.Mapping;

public class AlertApiProfile : Profile
{
    public AlertApiProfile()
    {
        CreateMap<AlertReportApiModel, AlertReport>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ReportId, opt => opt.MapFrom(src => src.MeldungId))
            .ForMember(dest => dest.AlertDate, opt => opt.MapFrom(src => GetDateTimeFromTimestamp(src.Timestamp)))
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
            .ForMember(dest => dest.Start, opt => opt.MapFrom(src => GetDateTimeFromTimestamp(src.Start)))
            .ForMember(dest => dest.End, opt => opt.MapFrom(src => GetDateTimeFromTimestamp(src.End)))
            .ForMember(dest => dest.AlertReports, opt => opt.MapFrom(src => src.AlertReports))
            .ForMember(dest => dest.AlertCategories, opt => opt.MapFrom(src => src.AlertCategories));
    }

    private DateTime GetDateTimeFromTimestamp(long timestamp)
    {
        return DateTimeOffset.FromUnixTimeMilliseconds(timestamp).DateTime;
    }

}
