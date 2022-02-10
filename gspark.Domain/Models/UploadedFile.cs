namespace gspark.Domain.Models
{
    public class UploadedFile : BaseEntity
    {
        public string FileName { get; set; }
        public double FileSize { get; set; }
        public DateTime UploadedDate { get; set; }
        public int UploadedBy { get; set; }

        public virtual User User { get; set; }
    }
}
