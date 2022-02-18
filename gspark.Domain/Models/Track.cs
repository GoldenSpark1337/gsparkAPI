using System.ComponentModel.DataAnnotations.Schema;

namespace gspark.Domain.Models
{
    public class Track : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public int UserId { get; set; }
        public byte[]? Artwork { get; set; }
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
        public string Bpm { get; set; } = string.Empty;
        public int TrackKey_Id { get; set; }
        public string Collaborator { get; set; } = string.Empty;
        public int GenreId { get; set; }
        public string SubGenre { get; set; } = string.Empty;
        public int Plays { get; set; } = 0;
        public int Likes { get; set; } = 0;

        public virtual User User { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Key Key { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<TrackPlaylist> TrackPlaylists { get; set; }
    }
}
