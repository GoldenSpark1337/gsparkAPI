using gspark.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace gspark.Repository;

public class IdentityContextSeed
{
    public static async Task SeedUsersAsync(UserManager<User> userManager)
    {
        if (!userManager.Users.Any())
        {
            var user = new User
            {
                UserName = "bob",
                Email = "bob@example.pl"
            };

            await userManager.CreateAsync(user, "Pa$$w0rd");
        }
    }
}