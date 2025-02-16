using AutoMapper;
using Hahn.Assesment.Application.DTOs.SeverityDtos;
using Hahn.Assesment.Application.Services.Interfaces;
using Hahn.Assesment.Domain.Entities;
using Hahn.Assesment.Persistence.Repositories.Interfaces;
using Hahn.Assesment.Persistence.Services.Interfaces;

namespace Hahn.Assesment.Application.Services;

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

    public async Task<AlertDto> GetAlertAsync()
    {
        var alertData = await _alertRepository.GetAlertAsync();
        var alertDto = _mapper.Map<AlertDto>(alertData);
        return alertDto;
    }
}
