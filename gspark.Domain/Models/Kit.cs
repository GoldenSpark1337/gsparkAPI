namespace gspark.Domain.Models
{
    public class Kit : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public byte[]? Artwork { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
