using System.ComponentModel.DataAnnotations.Schema;

namespace gspark.Domain.Models
{
    public class Track : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public byte[]? Artwork { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; } = DateTime.Now.Date;
        public string Bpm { get; set; } = string.Empty;
        public int TrackKey_Id { get; set; }
        public string Collaborator { get; set; } = string.Empty;
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public int? SubGenreId { get; set; }
        public virtual Subgenre Subgenre { get; set; }
        public virtual Key Key { get; set; }
        public int Plays { get; set; } = 0;
        public int Likes { get; set; } = 0;

        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<TrackPlaylist> TrackPlaylists { get; set; }
    }
}
