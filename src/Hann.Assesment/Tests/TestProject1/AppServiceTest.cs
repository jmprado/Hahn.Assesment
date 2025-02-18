using AutoMapper;
using FluentAssertions;
using Hahn.Assesment.Application.DTOs;
using Hahn.Assesment.Application.DTOs.SeverityDtos;
using Hahn.Assesment.Application.Mapping;
using Hahn.Assesment.Application.Services;
using Hahn.Assesment.Domain.Entities;
using Hahn.Assesment.Persistence.Repositories.AlertRepository;
using Hahn.Assesment.Persistence.Repositories.Category;
using Hahn.Assesment.Persistence.Repositories.Report;
using Moq;

namespace Hahn.Assesment.Tests;

public class AlertAppServiceTests
{
    private readonly Mock<IAlertRepository> _alertRepositoryMock;
    private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
    private readonly Mock<IReportRepository> _reportRepositoryMock;
    private readonly IMapper _mapper;
    private readonly AlertAppService _alertAppService;

    public AlertAppServiceTests()
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new AlertAppProfile());
        });
        IMapper mapper = mappingConfig.CreateMapper();
        _mapper = mapper;

        _alertRepositoryMock = new Mock<IAlertRepository>();
        _categoryRepositoryMock = new Mock<ICategoryRepository>();
        _reportRepositoryMock = new Mock<IReportRepository>();

        _alertAppService = new AlertAppService(
            _alertRepositoryMock.Object,
            _categoryRepositoryMock.Object,
            _reportRepositoryMock.Object,
            _mapper);
    }

    [Fact]
    public async Task GetCurrentAlertAsync_ReturnsAlertDto()
    {
        // Arrange
        var alert = new AlertEntity
        {
            Id = Guid.NewGuid(),
            UpdatedAt = DateTime.UtcNow,
            Start = DateTime.UtcNow.AddHours(-1),
            End = DateTime.UtcNow.AddHours(1),
            WindowsSizeHours = 2
        };

        _alertRepositoryMock.Setup(repo => repo.GetCurrentAlertAsync()).ReturnsAsync(alert);

        // Act
        var result = await _alertAppService.GetCurrentAlertAsync();
        var mapped = _mapper.Map<AlertDto>(alert);

        // Assert
        result.Should().BeEquivalentTo(mapped);
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
        result.Should().BeEquivalentTo(categories);
    }

    [Fact]
    public async Task GetReportsAsync_ReturnsAlertReportDtos()
    {
        // Arrange
        var alertId = Guid.NewGuid();
        var reports = new List<AlertReport>
        {
            new AlertReport
            {
                Id = Guid.NewGuid(),
                ReportId = 1,
                ReportDate = DateTime.UtcNow,
                Lat = "40.7128",
                Lon = "-74.0060",
                Place = "New York",
                Category = "Weather",
                Condition = "Rain",
                ExtraAttribute = new List<string> { "Heavy" },
                LikeCount = 10,
                ImageUrl = "http://example.com/image.jpg",
                ImageThumbUrl = "http://example.com/thumb.jpg",
                ImageMediumUrl = "http://example.com/medium.jpg",
                BlurHash = "LKO2?U%2Tw=w]~RBVZRi};RPxuwH",
                ImageThumbWidth = 100,
                ImageThumbHeight = 100,
                AlertId = alertId
            }
        };

        _reportRepositoryMock.Setup(repo => repo.GetAlertReportsAsync(alertId)).ReturnsAsync(reports);


        // Act
        var result = await _alertAppService.GetReportsAsync(alertId);
        var mapped = _mapper.Map<IEnumerable<AlertReportDto>>(reports);

        // Assert
        result.Should().BeEquivalentTo(mapped);
    }
}

