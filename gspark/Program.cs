using MediatR;
using System.Reflection;
using NLog;
using NLog.Web;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using gspark.Domain.Identity;
using gspark.Service.Common.Behaviors;
using gspark.Service.Common.Mappings;
using gspark.Repository;
using gspark.Service.Features.Users.Queries.GetUser;
using gspark.Service.Features.Users.Commands.CreateUser;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using gspark.API.Dtos.UserDtos;
using gspark.Domain.Models;
using gspark.Extensions;
using gspark.Middleware;
using gspark.Models;
using gspark.Service.Contract;
using gspark.Service.Implementation;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

    // Add Controllers
    builder.Services.AddControllers().AddJsonOptions(options =>
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
        );
    
    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

    builder.Services.AddMediatR(typeof(GetUserQuery));

    builder.Services.AddValidatorsFromAssemblies(new [] { Assembly.GetAssembly(typeof(CreateUserCommandValidator)) });
    builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

    // Enable AutoMapper
    builder.Services.AddAutoMapper(config =>
    {
        config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
        config.AddProfile(new AssemblyMappingProfile(typeof(MarketPlaceContext).Assembly));
    });
    builder.Services.AddTransient(typeof(UrlResolver<,>));

    // Configure DbContext
    builder.Services.AddDbContext<MarketPlaceContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSql"))
            .UseSnakeCaseNamingConvention();
    });

    builder.Services.AddDbContext<IdentityContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("IdentityConnection"))
            .UseSnakeCaseNamingConvention();
    });
    
    // // Enable Identity
    // builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    //     .AddEntityFrameworkStores<MarketPlaceContext>();
    
    // DI Services
    builder.Services.AddApplicationServices();
    builder.Services.AddIdentityServices(builder.Configuration);
    builder.Services.AddSwaggerDocumentation();

    builder.Services.Configure<IdentityOptions>(options =>
    {
        // Password settings
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 6;
    });

    var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(
            name: myAllowSpecificOrigins,
            builder => builder.AllowAnyMethod().AllowAnyHeader().WithOrigins("https://localhost:4200"));
    });

    WebApplication app = builder.Build();
    
    app.UseMiddleware<ExceptionMiddleware>();
    
    // Use ExceptionHandler
    app.UseStatusCodePagesWithReExecute("/errors/{0}");
    
    //Use HSTS

    //Use HttpsRedirection
    app.UseHttpsRedirection();

    // Use Static Files
    app.UseStaticFiles();
    
    // Use Routing
    app.UseRouting();

    // Use CORS
    app.UseCors("_myAllowSpecificOrigins");

    // Use Authentication
    app.UseAuthentication();

    // Use Authorization
    app.UseAuthorization();
    //app.UseIdentityServer();

    // Use Swagger
    app.UseSwaggerDocumentation();

    using (var scope = app.Services.CreateScope())
    {
        var serviceProvider = scope.ServiceProvider;
        try
        {
            var context = serviceProvider.GetRequiredService<MarketPlaceContext>();
            DbInitializer.Initialize(context);
            await MarketPlaceContextSeed.SeedAsync(context, logger);

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var identityContext = serviceProvider.GetRequiredService<IdentityContext>();
            await identityContext.Database.MigrateAsync();
            await IdentityContextSeed.SeedUsersAsync(userManager);
        }
        catch (Exception ex)
        {
            logger.Log(NLog.LogLevel.Trace, ex.Message);
            logger.Error(ex, ex.Message);
            throw new Exception(ex.Message);
        }
    }

    // Use EndPoints
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    app.Run();
} 
catch (Exception exception)
{
    logger.Log(NLog.LogLevel.Trace, exception.Message);

    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit
    NLog.LogManager.Shutdown();
}