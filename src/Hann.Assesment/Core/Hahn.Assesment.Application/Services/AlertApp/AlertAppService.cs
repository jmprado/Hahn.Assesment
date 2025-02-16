using AutoMapper;
using Hahn.Assesment.Application.DTOs.SeverityDtos;
using Hahn.Assesment.Domain.Entities;
using Hahn.Assesment.Persistence.Repositories.Interfaces;
using Hahn.Assesment.Persistence.Services.AlertApi;
using Hangfire;

namespace Hahn.Assesment.Application.Services.AlertApp;

public class AlertAppService : IAlertAppService
{
    private readonly IAlertApiService _alertApiService;
    private readonly IAlertRepository _alertRepository;
    private readonly IMapper _mapper;

    public AlertAppService(IAlertApiService alertApiService, IAlertRepository alertRepository, IMapper mapper)
    {
        _mapper = mapper;
        _alertApiService = alertApiService;
        _alertRepository = alertRepository;
    }

    public async Task LoadAlertDataAsync()
    {
        var alertData = await _alertApiService.GetAlertDataAsync();
        var alertEntity = _mapper.Map<AlertEntity>(alertData);
        await _alertRepository.SaveAlertAsync(alertEntity);
    }

    public async Task SaveAlertReport(IEnumerable<AlertReport> alertReports)
    {
        foreach (var alertReport in alertReports)
            BackgroundJob.Enqueue("AddAlertReportRow", () => _alertRepository.SaveAlertReport(alertReport));
    }

    public async Task<AlertDto> GetAlertAsync()
    {
        var alertData = await _alertRepository.GetAlertAsync();
        var alertDto = _mapper.Map<AlertDto>(alertData);
        return alertDto;
    }
}
