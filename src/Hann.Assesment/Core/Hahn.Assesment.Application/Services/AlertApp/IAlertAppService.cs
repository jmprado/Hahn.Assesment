using Hahn.Assesment.Application.DTOs.SeverityDtos;

namespace Hahn.Assesment.Application.Services.AlertApp
{
    public interface IAlertAppService
    {
        Task<AlertDto> GetAlertAsync();
        Task LoadAlertDataAsync();
    }
}