using System;
using System.Collections.Generic;
using System.Linq;
namespace gspark.Domain.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public byte[]? Image { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public int? RecordLabelId { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<UploadedFile> UploadedFiles { get; set; }
        public virtual ICollection<Kit> Kits { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual RecordLabel? RecordLabel { get; set; }
    }
}
