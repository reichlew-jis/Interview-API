using System.Threading.Tasks;
using AutoFixture;
using Interview.Api.Integration.Test.Setup;
using Xunit;

namespace Interview.Api.Integration.Test.Controllers.TenantsController;

[Collection(nameof(MockWebApiCollection))]
public class GetTenantByIdTests
{
    private const string BASE_URL = "/Tenant";

    private static readonly Fixture _fixture = new();

    private readonly MockWebApiFactory _factory;

    public GetTenantByIdTests(MockWebApiFactory factory)
    {
        _factory = factory;
    }

    [Fact(Skip = "Need to Implement")]
    public async Task ShouldReturnOkWhenTenantExists()
    {
        // Arrange
        //var client = _factory.CreateClient();

        //var context = _factory.GetContext();

        //var tenantEntity = _fixture.Create<TenantEntity>();

        //await context.Tenants.AddAsync(tenantEntity);
        //await context.SaveChangesAsync();

        //var url = $"{BASE_URL}/{tenantEntity.Id}";

        // Act
        //var response = await client.GetAsync(url);
        //var content = await response.Content.ReadFromJsonAsync<Tenant>();

        // Assert
        //response.StatusCode.Should().Be(HttpStatusCode.OK);

        //content.Should().BeEquivalentTo(tenantEntity);
    }

    [Fact(Skip = "Need to Implement")]
    public async Task ShouldReturnNotFoundWhenTenantDoesNotExist()
    {
        // Arrange
        //var client = _factory.CreateClient();

        //var url = $"{BASE_URL}/9999";

        // Act
        //var response = await client.GetAsync(url);

        // Assert
        //response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
