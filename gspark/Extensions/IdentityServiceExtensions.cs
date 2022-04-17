using System.Text;
using gspark.Domain.Identity;
using gspark.Domain.Models;
using gspark.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace gspark.Extensions;

public static class IdentityServiceExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
        var builder = services.AddIdentityCore<User>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddRoles<UserRole>()
            .AddRoleManager<RoleManager<UserRole>>()
            .AddSignInManager<SignInManager<User>>()
            .AddRoleValidator<RoleValidator<UserRole>>()
            .AddEntityFrameworkStores<MarketPlaceContext>();

        builder = new IdentityBuilder(builder.UserType, builder.Services);

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"])),
                    ValidIssuer = config["JWT:ValidIssuer"],
                    ValidateIssuer = true,
                    ValidateAudience = false
                };
            });
        
        services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminRole", policy => policy.RequireRole("Admin"));
            options.AddPolicy("ProPage", policy => policy.RequireRole("Admin", "ProPage"));
        });
        
        return services;
    }
}