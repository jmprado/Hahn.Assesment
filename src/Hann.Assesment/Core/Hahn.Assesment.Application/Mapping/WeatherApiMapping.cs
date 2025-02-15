using AutoMapper;
using Hahn.Assesment.Domain.Entities;
using Hahn.Assesment.Domain.SeverityService;

namespace Hahn.Assesment.Application.Mapping;

public class WeatherApiMapping : Profile
{
    public WeatherApiMapping()
    {
        CreateMap<MeldungenModel, SeverityReport>()
            .ForMember(dest => dest.ReportId, opt => opt.MapFrom(src => src.MeldungId))
            .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.Timestamp))
            .ForMember(dest => dest.Lat, opt => opt.MapFrom(src => src.Lat))
            .ForMember(dest => dest.Lon, opt => opt.MapFrom(src => src.Lon))
            .ForMember(dest => dest.Place, opt => opt.MapFrom(src => src.Place))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => src.Auspraegung))
            .ForMember(dest => dest.ExtraAttribute, opt => opt.MapFrom(src => src.ZusatzAttribute))
            .ForMember(dest => dest.LikeCount, opt => opt.MapFrom(src => src.LikeCount))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
            .ForMember(dest => dest.ImageThumbUrl, opt => opt.MapFrom(src => src.ImageThumbUrl))
            .ForMember(dest => dest.ImageMediumUrl, opt => opt.MapFrom(src => src.ImageMediumUrl))
            .ForMember(dest => dest.BlurHash, opt => opt.MapFrom(src => src.BlurHash))
            .ForMember(dest => dest.ImageThumbWidth, opt => opt.MapFrom(src => src.ImageThumbWidth))
            .ForMember(dest => dest.ImageThumbHeight, opt => opt.MapFrom(src => src.ImageThumbHeight))
            .ForMember(dest => dest.SeverityAlertId, opt => opt.Ignore());

        CreateMap<HighestSeverityModel, SeverityCategory>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => src.Auspraegung))
            .ForMember(dest => dest.SeverityAlertId, opt => opt.Ignore())
            .ForMember(dest => dest.SeverityAlert, opt => opt.Ignore());

        CreateMap<AlertApiModel, SeverityAlert>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now));
    }
}
