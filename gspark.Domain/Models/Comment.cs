namespace gspark.Domain.Models
{
    public class Comment
    {
        public string CommentDetail { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public int TrackId { get; set; }

        public virtual User User { get; set; }
        public virtual Track Track { get; set; }

    }
}
