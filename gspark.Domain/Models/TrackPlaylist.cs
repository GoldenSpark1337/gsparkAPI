namespace gspark.Domain.Models
{
    public class TrackPlaylist
    {
        public int TrackId { get; set; }
        public int PlaylistId { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Track Track { get; set; }
        public virtual Playlist Playlist { get; set; }
    }
}
