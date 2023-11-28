using Interview.Api.Configuration.Extensions;
using Interview.Api.Configuration.Models;
using Interview.Data.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Interview.Api;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddOptions();

        var connectionStrings = _configuration.GetSection("ConnectionStrings");

        services.Configure<InterviewConnectionStrings>(connectionStrings);

        var connectionStringsOptions = Options.Create(connectionStrings.Get<InterviewConnectionStrings>());

        services.AddControllers();

        services.ProvideDataServices(connectionStringsOptions);

        services.ProvideSwaggerServices();

        services.AddAutoMapper(typeof(SelectedTenantProfile));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHsts();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.ConfigureSwagger();

        app.MigrateDatabase();
    }
}
