using gspark.Service.Common.Exceptions;
using gspark.Service.Contract;
using gspark.Service.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace gspark.Extensions;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ITrackRepository, TrackService>();
        services.AddScoped<IGenreRepository, GenreService>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                var errors = actionContext.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage);
                var errorResponse = new ApiValidationErrorResponse {Errors = errors};
                return new BadRequestObjectResult(errorResponse);
            };
        });

        return services;
    }
}