namespace gspark.Domain.Models
{
    public class TrackPlaylist
    {
        public DateTime CreatedAt { get; set; }
        public int TrackId { get; set; }
        public int PlaylistId { get; set; }

        public virtual Track Track { get; set; }
        public virtual Playlist Playlist { get; set; }
    }
}
