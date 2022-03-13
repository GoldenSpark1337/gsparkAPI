namespace gspark.Domain.Models
{
    public class UploadedFile : BaseEntity
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public double FileSize { get; set; }
        public string FileExtension { get; set; }
        public string MimeType { get; set; }
        public DateTime UploadedDate { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
