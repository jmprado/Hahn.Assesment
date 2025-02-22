using Hahn.Assesment.Application.Services;
using Hahn.Assesment.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Hahn.Assesment.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlertsController : ControllerBase
    {
        private readonly IAlertService _alertAppService;
        private readonly ILogger<AlertsController> _logger;

        public AlertsController(IAlertService alertAppService, ILogger<AlertsController> logger)
        {
            _alertAppService = alertAppService;
            _logger = logger;
        }

        [HttpGet("{id}/alert")]
        [ProducesResponseType(typeof(AlertDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAlertByIdAsync(Guid id)
        {
            var alert = await _alertAppService.GetAlertByIdAsync(id);
            if (alert == null)
            {
                _logger.LogInformation("No alert found in database");
                return new NotFoundObjectResult("No Alert found");
            }

            return Ok(alert);
        }

        [HttpGet("current")]
        [ProducesResponseType(typeof(AlertDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCurrentAlertAsync()
        {
            var alert = await _alertAppService.GetCurrentAlertAsync();
            if (alert == null)
            {
                _logger.LogInformation("No alert found in database");
                return new NotFoundObjectResult("No Alert found");
            }

            return Ok(alert);
        }

        [HttpGet("categories/{alertId}")]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCategoriesAsync(Guid alertId)
        {
            var categories = await _alertAppService.GetCategoriesAsync(alertId);
            return Ok(categories);
        }

        [HttpGet("reports/{alertId}")]
        [ProducesResponseType(typeof(IEnumerable<AlertReportDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetReportsAsync(Guid alertId)
        {
            var reports = await _alertAppService.GetReportsAsync(alertId);
            return Ok(reports);
        }
    }
}
