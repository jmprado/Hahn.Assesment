using AutoMapper;
using Hahn.Assesment.Application.DTOs;
using Hahn.Assesment.Application.DTOs.SeverityDtos;
using Hahn.Assesment.Domain.Entities;

namespace Hahn.Assesment.Application.Mapping
{
    public class AlertAppProfile : Profile
    {
        public AlertAppProfile()
        {
            CreateMap<AlertReport, AlertReportDto>()
                .ForMember(dest => dest.ReportDate, opt => opt.MapFrom(src => src.ReportDate.ToString("dd/MM/yyyy HH:mm")));
            CreateMap<AlertCategory, AlertCategoryDto>();
            CreateMap<AlertEntity, AlertDto>()
                .ForMember(dest => dest.Start, opt => opt.MapFrom(src => src.Start.ToString("dd/MM/yyyy HH:mm")))
                .ForMember(dest => dest.End, opt => opt.MapFrom(src => src.End.ToString("dd/MM/yyyy HH:mm")))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt.ToString("dd/MM/yyyy HH:mm")));
        }
    }
}
