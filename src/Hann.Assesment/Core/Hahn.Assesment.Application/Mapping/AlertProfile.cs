using AutoMapper;
using Hahn.Assesment.Application.DTOs;
using Hahn.Assesment.Domain.Entities;

namespace Hahn.Assesment.Application.Mapping
{
    public class AlertProfile : Profile
    {
        public AlertProfile()
        {
            CreateMap<AlertReport, AlertReportDto>();
            CreateMap<AlertCategory, AlertCategoryDto>();
            CreateMap<AlertEntity, AlertDto>();
        }
    }
}
