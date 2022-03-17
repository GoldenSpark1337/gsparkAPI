using gspark.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace gspark.Domain.Identity;

public class AppUserRole : IdentityUserRole<int>
{
    public virtual User User { get; set; }
    public virtual UserRole Role { get; set; }
}