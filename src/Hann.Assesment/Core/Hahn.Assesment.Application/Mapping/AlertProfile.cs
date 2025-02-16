﻿using AutoMapper;
using Hahn.Assesment.Application.DTOs;
using Hahn.Assesment.Application.DTOs.SeverityDtos;
using Hahn.Assesment.Domain.Entities;

namespace Hahn.Assesment.Application.Mapping
{
    public class AlertProfile : Profile
    {
        public AlertProfile()
        {
            CreateMap<AlertReport, AlertReportDto>();
            CreateMap<AlertCategory, AlertCategoryDto>();
            CreateMap<AlertEntity, AlertDto>()
                .ForMember(dest => dest.SeverityReports, opt => opt.MapFrom(src => src.AlertReports))
                .ForMember(dest => dest.SeverityCategories, opt => opt.MapFrom(src => src.AlertReports));
        }
    }
}
