using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Interview.Api.Integration.Test.Setup;
using Interview.Data.Entities;
using Interview.Data.Models;
using Xunit;

namespace Interview.Api.Integration.Test.Controllers.SelectedTenantController;

[Collection(nameof(MockWebApiCollection))]
public class GetSelectedTenantTests
{
    private const string BASE_URL = "/SelectedTenant";

    private static readonly Fixture _fixture = new();

    private readonly MockWebApiFactory _factory;

    public GetSelectedTenantTests(MockWebApiFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task ShouldReturnOkWhenEmailExists()
    {
        // Arrange
        var client = _factory.CreateClient();

        var context = _factory.GetContext();

        var selectedTenantEntity = _fixture.Create<SelectedTenantEntity>();

        await context.SelectedTenants.AddAsync(selectedTenantEntity);
        await context.SaveChangesAsync();

        var url = $"{BASE_URL}?email={selectedTenantEntity.Email}";

        // Act
        var response = await client.GetAsync(url);
        var content = await response.Content.ReadFromJsonAsync<SelectedTenant>();

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        content.Should().BeEquivalentTo(selectedTenantEntity);
    }

    [Fact]
    public async Task ShouldReturnNotFoundWhenEmailDoesNotExist()
    {
        // Arrange
        var client = _factory.CreateClient();

        var url = $"{BASE_URL}?email=Some-Email";

        // Act
        var response = await client.GetAsync(url);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
