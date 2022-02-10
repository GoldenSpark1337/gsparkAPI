namespace gspark.Domain.Identity
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public string Username { get; set; }
    }
}
