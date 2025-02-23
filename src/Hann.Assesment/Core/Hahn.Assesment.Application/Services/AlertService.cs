using AutoMapper;
using Hahn.Assesment.Domain.DTOs;
using Hahn.Assesment.Domain.Models.AlertApi;
using Hahn.Assesment.Domain.Models.Entities;
using Hahn.Assesment.Persistence.ExternalServices.AlertApi;
using Hahn.Assesment.Persistence.Repositories.AlertRepository;
using Hahn.Assesment.Persistence.Repositories.Category;
using Hahn.Assesment.Persistence.Repositories.Report;

namespace Hahn.Assesment.Application.Services;

public class AlertService : IAlertService
{
    private readonly IAlertRepository _alertRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IReportRepository _reportRepository;
    private readonly IApiService _alertApiService;

    private readonly IMapper _mapper;

    public AlertService(
        IAlertRepository alertRepository,
        ICategoryRepository categoryRepository,
        IReportRepository reportRepository,
        IApiService alertApiService,
        IMapper mapper)
    {
        _alertRepository = alertRepository;
        _categoryRepository = categoryRepository;
        _reportRepository = reportRepository;
        _alertApiService = alertApiService;
        _mapper = mapper;
    }

    #region Readers
    /// <summary>
    /// Get all alerts from database
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<AlertDto>> GetAlertsAsync()
    {
        var alertsData = await _alertRepository.GetAlertsAsync();
        var alertsDto = _mapper.Map<IEnumerable<AlertDto>>(alertsData);
        return alertsDto;
    }

    /// <summary>
    /// Get the current alert from database
    /// </summary>
    /// <returns></returns>
    public async Task<AlertDto?> GetCurrentAlertAsync()
    {
        var alertData = await _alertRepository.GetCurrentAlertAsync();
        var alertDto = _mapper.Map<AlertDto>(alertData);
        return alertDto;
    }


    /// <summary>
    /// Get the categories of a alert
    /// </summary>
    /// <param name="alertId"></param>
    /// <returns><c>ApiModel</c></returns>
    public async Task<IEnumerable<string>> GetCategoriesAsync(Guid alertId)
    {
        return await _categoryRepository.GetCategoriesAsync(alertId);
    }


    /// <summary>
    /// Get the reports of a alert
    /// </summary>
    /// <param name="alertId"></param>
    /// <returns></returns>
    public async Task<IEnumerable<AlertReportDto>> GetReportsAsync(Guid alertId)
    {
        var reports = await _reportRepository.GetAlertReportsAsync(alertId);
        var reportsDto = _mapper.Map<IEnumerable<AlertReportDto>>(reports);
        return reportsDto;
    }


    /// <summary>
    /// Get a alert by id
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    public async Task<AlertDto?> GetAlertByIdAsync(Guid guid)
    {
        var alert = await _alertRepository.GetAlertByIdAsync(guid);
        var alertDto = _mapper.Map<AlertDto>(alert);
        return alertDto;
    }


    /// <summary>
    /// Load the data from the Api and return the model
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<AlertModel?> LoadApiDataAsync()
    {
        var alertData = await _alertApiService.GetAlertDataAsync();

        if (alertData == null)
            throw new ArgumentNullException(nameof(alertData));

        return alertData;
    }
    #endregion

    #region Writers
    /// <summary>
    /// Save a alert in database and return the id created
    /// </summary>
    /// <param name="alertModel"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<Guid> AddAlertAsync(AlertModel alertModel)
    {
        if (alertModel == null)
            throw new ArgumentNullException(nameof(alertModel));

        var alertEntity = _mapper.Map<AlertEntity>(alertModel);
        var alertId = await _alertRepository.AddAlertAsync(alertEntity);
        return alertId;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="alertId"></param>
    /// <param name="categories"></param>
    /// <returns></returns>
    public async Task AddCategoriesAsync(Guid alertId, IEnumerable<CategoryModel> categories)
    {
        var categoriesEntity = _mapper.Map<IEnumerable<CategoryEntity>>(categories);

        foreach (var category in categoriesEntity)
            category.AlertId = alertId;

        await _categoryRepository.AddCategoriesAsync(categoriesEntity);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="alertId"></param>
    /// <param name="report"></param>
    /// <returns></returns>
    public async Task AddReportAsync(Guid alertId, ReportModel report)
    {
        var reportEntity = _mapper.Map<ReportEntity>(report);
        reportEntity.AlertId = alertId;
        await _reportRepository.AddReportAsync(reportEntity);
    }
    #endregion
}
