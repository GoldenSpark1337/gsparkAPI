using Microsoft.AspNetCore.Identity;

namespace gspark.Domain.Identity
{
    public class UserRole : IdentityRole<int>
    {
        
        public virtual ICollection<AppUserRole> UserRoles { get; set; }
    }
}
