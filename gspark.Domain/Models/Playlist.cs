namespace gspark.Domain.Models
{
    public class Playlist : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public byte[]? Artwork { get; set; }
        public string Description { get; set; } = string.Empty;
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<TrackPlaylist> TrackPlaylists { get; set; }
    }
}
