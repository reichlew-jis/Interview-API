using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Interview.Api.Configuration.Extensions;

public static class SwaggerExtensions
{
    public static void ProvideSwaggerServices(this IServiceCollection services)
    {
        services.AddSwaggerGen(x =>
        {
            x.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Interview API",
                Version = "v1"
            });

            x.EnableAnnotations();
        });
    }

    public static void ConfigureSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();

        app.UseSwaggerUI(x =>
        {
            x.DocumentTitle = "Interview API";
            x.RoutePrefix = "api/docs";
            x.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        });
    }
}
