using AutoMapper;
using Hahn.Assesment.Application.DTOs;
using Hahn.Assesment.Application.Services;
using Hahn.Assesment.Domain.Entities;
using Hahn.Assesment.Persistence.Repositories.AlertRepository;
using Hahn.Assesment.Persistence.Repositories.Category;
using Hahn.Assesment.Persistence.Repositories.Report;
using Moq;

namespace Hahn.Assesment.Application.Tests;

public class AlertAppServiceTests
{
    private readonly Mock<IAlertRepository> _alertRepositoryMock;
    private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
    private readonly Mock<IReportRepository> _reportRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly AlertAppService _alertAppService;

    public AlertAppServiceTests()
    {
        _alertRepositoryMock = new Mock<IAlertRepository>();
        _categoryRepositoryMock = new Mock<ICategoryRepository>();
        _reportRepositoryMock = new Mock<IReportRepository>();
        _mapperMock = new Mock<IMapper>();

        _alertAppService = new AlertAppService(
            _alertRepositoryMock.Object,
            _categoryRepositoryMock.Object,
            _reportRepositoryMock.Object,
            _mapperMock.Object);
    }

    [Fact]
    public async Task GetCurrentAlertAsync_ReturnsAlertDto()
    {
        // Arrange
        var alert = new AlertEntity();
        var alertDto = new AlertDto();
        _alertRepositoryMock.Setup(repo => repo.GetCurrentAlertAsync()).ReturnsAsync(alert);
        _mapperMock.Setup(mapper => mapper.Map<AlertDto>(alert)).Returns(alertDto);

        // Act
        var result = await _alertAppService.GetCurrentAlertAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(alertDto, result);
    }

    [Fact]
    public async Task GetCategoriesAsync_ReturnsCategories()
    {
        // Arrange
        var alertId = Guid.NewGuid();
        var categories = new List<string> { "Category1", "Category2" };
        _categoryRepositoryMock.Setup(repo => repo.GetCategoriesAsync(alertId)).ReturnsAsync(categories);

        // Act
        var result = await _alertAppService.GetCategoriesAsync(alertId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(categories, result);
    }

    [Fact]
    public async Task GetReportsAsync_ReturnsAlertReportDtos()
    {
        // Arrange
        var alertId = Guid.NewGuid();
        var reports = new List<AlertReport>();
        var reportsDto = new List<AlertReportDto>();
        _reportRepositoryMock.Setup(repo => repo.GetAlertReportsAsync(alertId, It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(reports);
        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<AlertReportDto>>(reports)).Returns(reportsDto);

        // Act
        var result = await _alertAppService.GetReportsAsync(alertId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(reportsDto, result);
    }
}