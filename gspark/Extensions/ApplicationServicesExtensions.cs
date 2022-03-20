using gspark.Repository;
using gspark.Service.Common.Exceptions;
using gspark.Service.Common.Mappings;
using gspark.Service.Contract;
using gspark.Service.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace gspark.Extensions;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IUserRepository, UserService>();
        services.AddScoped<IGenreRepository, GenreService>();
        services.AddScoped<IBasketRepository, BasketRepository>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        
        // Enable AutoMapper
        services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(typeof(AssemblyMappingProfile).Assembly));
            config.AddProfile(new AssemblyMappingProfile(typeof(MarketPlaceContext).Assembly));
        });
        services.AddTransient(typeof(UrlResolver<,>));
        
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