using Hahn.Assesment.Application.DTOs.SeverityDtos;
using Hahn.Assesment.Domain.Services.Interfaces;
using Hahn.Assesment.Infrastructure.Persistence.Repositories;
using Hahn.Assesment.Persistence.Services.Interfaces;

namespace Hahn.Assesment.Application.Services;

public class AlertAppService : IAlertAppService
{
    private readonly IAlertApiService _alertApiService;
    private readonly IAlertRepository _alertRepository;

    public AlertAppService(IAlertApiService alertApiService, IAlertRepository alertRepository)
    {
        _alertApiService = alertApiService;
        _alertRepository = alertRepository;
    }

    public Task LoadAlertDataAsync()
    {
        var alertData = _alertApiService.GetAlertDataAsync();
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AlertDto>> GetAlertAsync()
    {
        throw new NotImplementedException();
    }
}
