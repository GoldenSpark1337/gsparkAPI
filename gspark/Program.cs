using MediatR;
using System.Reflection;
using NLog;
using NLog.Web;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using gspark;
using gspark.Domain.Identity;
using gspark.Service.Common.Behaviors;
using gspark.Service.Common.Mappings;
using gspark.Repository;
using gspark.Service.Features.Users.Queries.GetUser;
using gspark.Service.Features.Users.Commands.CreateUser;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

    var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

    builder.Services.AddControllers();

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();


    builder.Services.AddMediatR(typeof(GetUserQuery));

    builder.Services.AddValidatorsFromAssemblies(new [] { Assembly.GetAssembly(typeof(CreateUserCommandValidator)) });
    builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

    builder.Services.AddAutoMapper(config =>
    {
        config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
        config.AddProfile(new AssemblyMappingProfile(typeof(MarketPlaceContext).Assembly));
    });

    // Enable Swagger
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(
        opt => opt.OperationFilter<SwaggerFileOperationFilter>());

    // Configure DbContext
    builder.Services.AddDbContext<MarketPlaceContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
    });

    // Enable Identity
    builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<MarketPlaceContext>();

    builder.Services.Configure<IdentityOptions>(options =>
    {
        // Password settings
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 6;
    });

    // Enable CORS
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(
            name: myAllowSpecificOrigins,
            builder => {
                builder.WithOrigins("https://localhost:4200")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
            });
    });

    WebApplication app = builder.Build();

    // Use ExceptionHandler

    //Use HSTS

    //Use HttpsRedirection
    app.UseHttpsRedirection();

    // Use Static Files

    // Use Routing
    app.UseRouting();

    // Use CORS
    app.UseCors();

    // Use Authentication
    //app.UseAuthentication();

    // Use Authorization
    //app.UseIdentityServer();

    // Use Swagger
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var serviceProvider = scope.ServiceProvider;
        try
        {
            var context = serviceProvider.GetRequiredService<MarketPlaceContext>();
            DbInitializer.Initialize(context);
        }
        catch (Exception ex)
        {
            logger.Trace(ex.Message);
            throw new Exception();
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
    logger.Trace(exception.Message);
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit
    NLog.LogManager.Shutdown();
}