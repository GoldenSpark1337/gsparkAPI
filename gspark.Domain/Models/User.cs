using System;
using System.Collections.Generic;
using System.Linq;
using gspark.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace gspark.Domain.Models
{
    public class User : IdentityUser<int>, IBaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Image { get; set; } = "images/users/user_undefined.jpg";
        public string Location { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public int? RecordLabelId { get; set; }

        
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual RecordLabel? RecordLabel { get; set; }
        public virtual ICollection<AppUserRole> UserRoles { get; set; }
        public virtual ICollection<UserProductLike> Likes { get; set; }
        public virtual ICollection<Message> MessagesSent { get; set; }
        public virtual ICollection<Message> MessagesReceived { get; set; }
    }
}
