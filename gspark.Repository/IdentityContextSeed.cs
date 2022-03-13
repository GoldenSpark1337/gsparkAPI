using gspark.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace gspark.Repository;

public class IdentityContextSeed
{
    public static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager)
    {
        if (!userManager.Users.Any())
        {
            var user = new ApplicationUser
            {
                DisplayName = "bob",
                UserName = "bob",
                Email = "bob@example.pl"
            };

            await userManager.CreateAsync(user, "Pa$$w0rd");
        }
    }
}