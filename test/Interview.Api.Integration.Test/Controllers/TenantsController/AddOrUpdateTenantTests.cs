using System.Threading.Tasks;
using AutoFixture;
using Interview.Api.Integration.Test.Setup;
using Xunit;

namespace Interview.Api.Integration.Test.Controllers.TenantsController;

[Collection(nameof(MockWebApiCollection))]
public class AddOrUpdateTenantTests
{
    private const string BASE_URL = "/Tenant";

    private static readonly Fixture _fixture = new();

    private readonly MockWebApiFactory _factory;

    public AddOrUpdateTenantTests(MockWebApiFactory factory)
    {
        _factory = factory;
    }

    [Fact(Skip = "Need to Implement")]
    public async Task ShouldReturnOkWhenModelIsValid()
    {
        // Arrange
        //var client = _factory.CreateClient();

        //var tenant = _fixture.Create<Tenant>();

        // Act
        //var response = await client.PostAsJsonAsync(BASE_URL, tenant);

        // Assert
        //response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact(Skip = "Need to Implement")]
    public async Task ShouldReturnBadRequestWhenModelIsInvalid()
    {
        // Arrange
        //var client = _factory.CreateClient();

        //var tenant = _fixture.Build<Tenant>()
        //    .Without(x => x.Id)
        //    .Create();

        // Act
        //var response = await client.PostAsJsonAsync(BASE_URL, tenant);

        // Assert
        //response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}
