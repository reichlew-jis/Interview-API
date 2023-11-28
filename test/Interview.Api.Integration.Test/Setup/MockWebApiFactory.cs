using Interview.Data.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Interview.Api.Integration.Test.Setup;

public class MockWebApiFactory : WebApplicationFactory<Startup>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Development");
    }

    public InterviewContext GetContext()
    {
        var scope = Services.CreateScope();

        return scope.ServiceProvider.GetRequiredService<InterviewContext>();
    }
}
