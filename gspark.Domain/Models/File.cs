namespace gspark.Domain.Models
{
    public class File : BaseEntity
    {
        public string Url { get; set; }
        public string PublicId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
