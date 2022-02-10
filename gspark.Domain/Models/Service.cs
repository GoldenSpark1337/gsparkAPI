namespace gspark.Domain.Models
{
    public class Service : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public byte[]? Artwork { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
