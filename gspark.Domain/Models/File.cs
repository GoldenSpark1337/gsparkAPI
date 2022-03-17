namespace gspark.Domain.Models
{
    public class File : BaseEntity
    {
        public string FileName { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public double FileSize { get; set; }
        public string FileExtension { get; set; }
        public string MimeType { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
