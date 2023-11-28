using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Interview.Api.Controllers;
using Interview.Data.Models;
using Interview.Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Interview.Api.Test.Controllers;

public class SelectedTenantControllerTests
{
    private static readonly Fixture _fixture = new();

    private readonly Mock<IUserPreferenceService> _mockUserPreferenceService;

    private readonly SelectedTenantController _controller;

    public SelectedTenantControllerTests()
    {
        _mockUserPreferenceService = new Mock<IUserPreferenceService>();

        _controller = new SelectedTenantController(_mockUserPreferenceService.Object);
    }

    [Fact]
    public async Task AddOrUpdateSelectedTenant_ShouldReturnOkResult()
    {
        // Arrange
        var selectedTenant = _fixture.Create<SelectedTenant>();

        _mockUserPreferenceService
            .Setup(x => x.AddOrUpdateSelectedTenant(selectedTenant))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _controller.AddOrUpdateSelectedTenant(selectedTenant) as OkResult;

        // Assert
        result.Should().NotBeNull();
        _mockUserPreferenceService.Verify(x => x.AddOrUpdateSelectedTenant(selectedTenant), Times.Once);
    }

    [Fact]
    public async Task GetSelectedTenant_WhenRecordExists_ShouldReturnOkResultWithSelectedTenant()
    {
        // Arrange
        var selectedTenant = _fixture.Create<SelectedTenant>();

        var email = selectedTenant.Email;

        _mockUserPreferenceService
            .Setup(x => x.GetSelectedTenant(email))
            .Returns(Task.FromResult(selectedTenant));

        // Act
        var result = await _controller.GetSelectedTenant(email) as OkObjectResult;

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().BeEquivalentTo(selectedTenant);

        _mockUserPreferenceService.Verify(x => x.GetSelectedTenant(email), Times.Once);
    }

    [Fact]
    public async Task GetSelectedTenant_WhenRecordDoesNotExist_ShouldReturnNotFoundResult()
    {
        // Arrange
        var email = _fixture.Create<string>();

        _mockUserPreferenceService
            .Setup(x => x.GetSelectedTenant(email))
            .Returns(Task.FromResult<SelectedTenant>(null));

        // Act
        var result = await _controller.GetSelectedTenant(email) as NotFoundResult;

        // Assert
        result.Should().NotBeNull();

        _mockUserPreferenceService.Verify(x => x.GetSelectedTenant(email), Times.Once);
    }
}
