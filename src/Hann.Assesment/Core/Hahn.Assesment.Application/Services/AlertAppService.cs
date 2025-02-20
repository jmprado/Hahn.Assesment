using AutoMapper;
using Hahn.Assesment.Application.DTOs;
using Hahn.Assesment.Application.DTOs.SeverityDtos;
using Hahn.Assesment.Persistence.Repositories.AlertRepository;
using Hahn.Assesment.Persistence.Repositories.Category;
using Hahn.Assesment.Persistence.Repositories.Report;

namespace Hahn.Assesment.Application.Services;

public class AlertAppService : IAlertAppService
{
    private readonly IAlertRepository _alertRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IReportRepository _reportRepository;
    private readonly IMapper _mapper;

    public AlertAppService(
        IAlertRepository alertRepository,
        ICategoryRepository categoryRepository,
        IReportRepository reportRepository,
        IMapper mapper)
    {
        _alertRepository = alertRepository;
        _categoryRepository = categoryRepository;
        _reportRepository = reportRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AlertDto>> GetAlertsAsync()
    {
        var alertsData = await _alertRepository.GetAlertsAsync();
        var alertsDto = _mapper.Map<IEnumerable<AlertDto>>(alertsData);
        return alertsDto;
    }

    public async Task<AlertDto> GetCurrentAlertAsync()
    {
        var alertData = await _alertRepository.GetCurrentAlertAsync();
        var alertDto = _mapper.Map<AlertDto>(alertData);
        return alertDto;
    }

    public async Task<IEnumerable<string>> GetCategoriesAsync(Guid alertId)
    {
        return await _categoryRepository.GetCategoriesAsync(alertId);
    }

    public async Task<IEnumerable<AlertReportDto>> GetReportsAsync(Guid alertId)
    {
        var reports = await _reportRepository.GetAlertReportsAsync(alertId);
        var reportsDto = _mapper.Map<IEnumerable<AlertReportDto>>(reports);
        return reportsDto;
    }

    public async Task<AlertDto?> GetAlertByIdAsync(Guid guid)
    {
        var alert = await _alertRepository.GetAlertByIdAsync(guid);
        var alertDto = _mapper.Map<AlertDto>(alert);
        return alertDto;
    }
}
