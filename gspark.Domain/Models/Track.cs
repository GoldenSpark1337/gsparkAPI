using System.ComponentModel.DataAnnotations.Schema;

namespace gspark.Domain.Models
{
    public class Track : Product
    {
        public string Mp3File { get; set; }
        public string? WavFile { get; set; }
        public string Bpm { get; set; } = string.Empty;
        public int? TrackKey_Id { get; set; }
        public string? Collaborator { get; set; } = string.Empty;
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public int? SubGenreId { get; set; }
        public virtual Subgenre Subgenre { get; set; }
        public virtual Key Key { get; set; }
        public int Plays { get; set; } = 0;

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<TrackPlaylist> TrackPlaylists { get; set; }
    }
}
