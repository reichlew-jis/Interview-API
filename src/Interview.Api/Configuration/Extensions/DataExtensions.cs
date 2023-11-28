using Interview.Api.Configuration.Models;
using Interview.Data.Contexts;
using Interview.Data.Services;
using Interview.Data.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Interview.Api.Configuration.Extensions;

public static class DataExtensions
{
    public static void MigrateDatabase(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

        var context = serviceScope.ServiceProvider.GetService<InterviewContext>();

        context.Database.Migrate();
    }

    public static void ProvideDataServices(this IServiceCollection services, IOptions<InterviewConnectionStrings> connectionStrings)
    {
        services.AddScoped<IUserPreferenceService, UserPreferenceService>();

        services.AddDbContext<InterviewContext>(options =>
        {
            options.UseSqlServer(connectionStrings.Value.InterviewDbConnectionString);
            //options.UseInMemoryDatabase("InMemoryInterviewDb");
        });
    }
}
