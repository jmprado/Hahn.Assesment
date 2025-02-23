using AutoMapper;
using Hahn.Assesment.Application.Services;
using Hahn.Assesment.Domain.DTOs;
using Hahn.Assesment.Domain.Models.AlertApi;
using Hahn.Assesment.Domain.Models.Entities;
using Hahn.Assesment.Persistence.ExternalServices.AlertApi;
using Hahn.Assesment.Persistence.Repositories.AlertRepository;
using Hahn.Assesment.Persistence.Repositories.Category;
using Hahn.Assesment.Persistence.Repositories.Report;
using Moq;

namespace Hahn.Assesment.Tests.Services;

public class AlertServiceTests
{
    private readonly Mock<IAlertRepository> _alertRepositoryMock;
    private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
    private readonly Mock<IReportRepository> _reportRepositoryMock;
    private readonly Mock<IApiService> _alertApiServiceMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly AlertService _alertService;

    public AlertServiceTests()
    {
        _alertRepositoryMock = new Mock<IAlertRepository>();
        _categoryRepositoryMock = new Mock<ICategoryRepository>();
        _reportRepositoryMock = new Mock<IReportRepository>();
        _alertApiServiceMock = new Mock<IApiService>();
        _mapperMock = new Mock<IMapper>();

        _alertService = new AlertService(
            _alertRepositoryMock.Object,
            _categoryRepositoryMock.Object,
            _reportRepositoryMock.Object,
            _alertApiServiceMock.Object,
            _mapperMock.Object);
    }

    [Fact]
    public async Task GetAlertsAsync_ShouldReturnAlerts()
    {
        // Arrange
        var alerts = new List<AlertEntity> { new AlertEntity { Id = Guid.NewGuid() } };
        var alertDtos = new List<AlertDto> { new AlertDto { Id = Guid.NewGuid() } };

        _alertRepositoryMock.Setup(repo => repo.GetAlertsAsync()).ReturnsAsync(alerts);
        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<AlertDto>>(alerts)).Returns(alertDtos);

        // Act
        var result = await _alertService.GetAlertsAsync();

        // Assert
        Assert.Equal(alertDtos, result);
    }

    [Fact]
    public async Task GetCurrentAlertAsync_ShouldReturnCurrentAlert()
    {
        // Arrange
        var alert = new AlertEntity { Id = Guid.NewGuid() };
        var alertDto = new AlertDto { Id = Guid.NewGuid() };

        _alertRepositoryMock.Setup(repo => repo.GetCurrentAlertAsync()).ReturnsAsync(alert);
        _mapperMock.Setup(mapper => mapper.Map<AlertDto>(alert)).Returns(alertDto);

        // Act
        var result = await _alertService.GetCurrentAlertAsync();

        // Assert
        Assert.Equal(alertDto, result);
    }

    [Fact]
    public async Task GetCategoriesAsync_ShouldReturnCategories()
    {
        // Arrange
        var alertId = Guid.NewGuid();
        var categories = new List<string> { "Category1", "Category2" };

        _categoryRepositoryMock.Setup(repo => repo.GetCategoriesAsync(alertId)).ReturnsAsync(categories);

        // Act
        var result = await _alertService.GetCategoriesAsync(alertId);

        // Assert
        Assert.Equal(categories, result);
    }

    [Fact]
    public async Task GetReportsAsync_ShouldReturnReports()
    {
        // Arrange
        var alertId = Guid.NewGuid();
        var reports = new List<ReportEntity> { new ReportEntity { Id = Guid.NewGuid() } };
        var reportDtos = new List<AlertReportDto> { new AlertReportDto { Id = Guid.NewGuid() } };

        _reportRepositoryMock.Setup(repo => repo.GetAlertReportsAsync(alertId)).ReturnsAsync(reports);
        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<AlertReportDto>>(reports)).Returns(reportDtos);

        // Act
        var result = await _alertService.GetReportsAsync(alertId);

        // Assert
        Assert.Equal(reportDtos, result);
    }

    [Fact]
    public async Task GetAlertByIdAsync_ShouldReturnAlert()
    {
        // Arrange
        var alertId = Guid.NewGuid();
        var alert = new AlertEntity { Id = alertId };
        var alertDto = new AlertDto { Id = alertId };

        _alertRepositoryMock.Setup(repo => repo.GetAlertByIdAsync(alertId)).ReturnsAsync(alert);
        _mapperMock.Setup(mapper => mapper.Map<AlertDto>(alert)).Returns(alertDto);

        // Act
        var result = await _alertService.GetAlertByIdAsync(alertId);

        // Assert
        Assert.Equal(alertDto, result);
    }

    [Fact]
    public async Task LoadApiDataAsync_ShouldReturnAlertData()
    {
        // Arrange
        var alertData = new AlertModel { Start = 1234567890, End = 1234567890, WindowsSizeHours = 1 };

        _alertApiServiceMock.Setup(service => service.GetAlertDataAsync()).ReturnsAsync(alertData);

        // Act
        var result = await _alertService.LoadApiDataAsync();

        // Assert
        Assert.Equal(alertData, result);
    }

    [Fact]
    public async Task AddAlertAsync_ShouldReturnAlertId()
    {
        // Arrange
        var alertModel = new AlertModel { Start = 1234567890, End = 1234567890, WindowsSizeHours = 1 };
        var alertEntity = new AlertEntity { Id = Guid.NewGuid() };

        _mapperMock.Setup(mapper => mapper.Map<AlertEntity>(alertModel)).Returns(alertEntity);
        _alertRepositoryMock.Setup(repo => repo.AddAlertAsync(alertEntity)).ReturnsAsync(alertEntity.Id);

        // Act
        var result = await _alertService.AddAlertAsync(alertModel);

        // Assert
        Assert.Equal(alertEntity.Id, result);
    }

    [Fact]
    public async Task AddCategoriesAsync_ShouldAddCategories()
    {
        // Arrange
        var alertId = Guid.NewGuid();
        var categories = new List<CategoryModel> { new CategoryModel { Category = "Category1", Auspraegung = "High" } };
        var categoryEntities = new List<CategoryEntity> { new CategoryEntity { Id = Guid.NewGuid(), AlertId = alertId } };

        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<CategoryEntity>>(categories)).Returns(categoryEntities);

        // Act
        await _alertService.AddCategoriesAsync(alertId, categories);

        // Assert
        _categoryRepositoryMock.Verify(repo => repo.AddCategoriesAsync(categoryEntities), Times.Once);
    }

    [Fact]
    public async Task AddReportAsync_ShouldAddReport()
    {
        // Arrange
        var alertId = Guid.NewGuid();
        var report = new ReportModel { MeldungId = 1, Lat = "0.0", Lon = "0.0", Category = "Category1", Auspraegung = "High" };
        var reportEntity = new ReportEntity { Id = Guid.NewGuid(), AlertId = alertId };

        _mapperMock.Setup(mapper => mapper.Map<ReportEntity>(report)).Returns(reportEntity);

        // Act
        await _alertService.AddReportAsync(alertId, report);

        // Assert
        _reportRepositoryMock.Verify(repo => repo.AddReportAsync(reportEntity), Times.Once);
    }
}