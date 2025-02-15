using AutoMapper;
using Hahn.Assesment.Application.DTOs;
using Hahn.Assesment.Application.DTOs.SeverityDtos;
using Hahn.Assesment.Domain.Entities;

namespace Hahn.Assesment.Application.Mapping
{
    public class SeverityAlertProfile : Profile
    {
        public SeverityAlertProfile()
        {
            CreateMap<SeverityReport, SeverityReportDto>();
            CreateMap<SeverityCategory, SeverityCategoryDto>();
            CreateMap<SeverityAlert, SeverityAlertDto>()
                .ForMember(dest => dest.SeverityReports, opt => opt.MapFrom(src => src.SeverityReport))
                .ForMember(dest => dest.SeverityCategories, opt => opt.MapFrom(src => src.SeverityReport));
        }
    }
}
