namespace gspark.Domain.Models
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public byte[]? Image { get; set; }
        public DateTime ReleaseDate { get; set; } = DateTime.Now.Date;
        public decimal Price { get; set; }
        public int ProductTypeId { get; set; }
        
        public virtual ProductType ProductType{ get; set; }
        public virtual Order Order { get; set; }
    }
}
