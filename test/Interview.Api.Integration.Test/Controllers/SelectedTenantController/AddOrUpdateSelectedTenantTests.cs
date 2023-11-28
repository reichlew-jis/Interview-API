using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Interview.Api.Integration.Test.Setup;
using Interview.Data.Models;
using Xunit;

namespace Interview.Api.Integration.Test.Controllers.SelectedTenantController;

[Collection(nameof(MockWebApiCollection))]
public class AddOrUpdateSelectedTenantTests
{
    private const string BASE_URL = "/SelectedTenant";

    private static readonly Fixture _fixture = new();

    private readonly MockWebApiFactory _factory;

    public AddOrUpdateSelectedTenantTests(MockWebApiFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task ShouldReturnOkWhenModelIsValid()
    {
        // Arrange
        var client = _factory.CreateClient();

        var selectedTenant = _fixture.Create<SelectedTenant>();

        // Act
        var response = await client.PostAsJsonAsync(BASE_URL, selectedTenant);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task ShouldReturnBadRequestWhenModelIsInvalid()
    {
        // Arrange
        var client = _factory.CreateClient();

        var selectedTenant = _fixture.Build<SelectedTenant>()
            .Without(x => x.Email)
            .Create();

        // Act
        var response = await client.PostAsJsonAsync(BASE_URL, selectedTenant);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}
