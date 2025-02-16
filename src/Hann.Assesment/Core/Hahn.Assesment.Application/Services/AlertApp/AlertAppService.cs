using AutoMapper;
using Hahn.Assesment.Application.DTOs.SeverityDtos;
using Hahn.Assesment.Persistence.Repositories.Interfaces;
using Hahn.Assesment.Persistence.Services.AlertApi;

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
        if (alertData == null)
            throw new ArgumentNullException(nameof(alertData));

        await _alertRepository.SaveAlertAsync(alertData);
    }

    public async Task<AlertDto> GetAlertAsync()
    {
        var alertData = await _alertRepository.GetAlertAsync();
        var alertDto = _mapper.Map<AlertDto>(alertData);
        return alertDto;
    }
}
