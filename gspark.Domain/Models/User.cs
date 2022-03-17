using System;
using System.Collections.Generic;
using System.Linq;
using gspark.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace gspark.Domain.Models
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Image { get; set; } = "images/users/user_undefined.jpg";
        public string Location { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public int? RecordLabelId { get; set; }

        
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<Kit> Kits { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual RecordLabel? RecordLabel { get; set; }
        public virtual ICollection<AppUserRole> UserRoles { get; set; }
    }
}
