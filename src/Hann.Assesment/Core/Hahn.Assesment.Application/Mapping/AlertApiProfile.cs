using AutoMapper;
using Hahn.Assesment.Domain.Models.AlertApi;
using Hahn.Assesment.Domain.Models.Entities;

namespace Hahn.Assesment.Application.Mapping;

public class AlertApiProfile : Profile
{
    public AlertApiProfile()
    {
        CreateMap<ReportModel, ReportEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ReportId, opt => opt.MapFrom(src => src.MeldungId))
            .ForMember(dest => dest.ReportDate, opt => opt.MapFrom(src => src.Timestamp.ToDateTimeFromTimestamp()))
            .ForMember(dest => dest.ExtraAttribute, opt => opt.MapFrom(src => src.ZusatzAttribute))
            .ForMember(dest => dest.AlertId, opt => opt.Ignore())
            .ForMember(dest => dest.Alerts, opt => opt.Ignore());

        CreateMap<CategoryModel, CategoryEntity>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => src.Auspraegung))
            .ForMember(dest => dest.AlertId, opt => opt.Ignore())
            .ForMember(dest => dest.Alerts, opt => opt.Ignore());

        CreateMap<AlertModel, AlertEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.Start, opt => opt.MapFrom(src => src.Start.ToDateTimeFromTimestamp()))
            .ForMember(dest => dest.End, opt => opt.MapFrom(src => src.End.ToDateTimeFromTimestamp()))
            .ForMember(dest => dest.AlertReports, opt => opt.Ignore())
            .ForMember(dest => dest.AlertCategories, opt => opt.Ignore());
    }
}

// TODO: move this to a new file
public static class LongExtensions
{
    public static DateTime ToDateTimeFromTimestamp(this long timestamp)
    {
        return DateTimeOffset.FromUnixTimeMilliseconds(timestamp).DateTime;
    }
}