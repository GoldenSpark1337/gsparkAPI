using Microsoft.OpenApi.Models;

namespace gspark.Extensions;

public static class SwaggerServiceExtensions
{
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        // Enable Swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(
            opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo {Title = "gspark API", Version = "v1"});
                opt.OperationFilter<SwaggerFileOperationFilter>();
            }    
        );
        
        return services;
    }

    public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        return app;
    }
}