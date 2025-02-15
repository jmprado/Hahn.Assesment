using Hahn.Assesment.Application.DTOs.SeverityDtos;

namespace Hahn.Assesment.Domain.Services.Interfaces;

public interface IAlertAppService
{
    Task<IEnumerable<AlertDto>> GetAlertAsync();
    Task LoadAlertDataAsync();
}