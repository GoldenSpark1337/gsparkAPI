using System.Text;
using gspark.Domain.Identity;
using gspark.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace gspark.Extensions;

public static class IdentityServiceExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
        var builder = services.AddIdentityCore<ApplicationUser>();

        builder = new IdentityBuilder(builder.UserType, builder.Services);
        builder.AddEntityFrameworkStores<IdentityContext>();
        builder.AddSignInManager<SignInManager<ApplicationUser>>();

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
        

        return services;
    }
}