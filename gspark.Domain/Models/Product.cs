using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace gspark.Domain.Models
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string? Image { get; set; }
        public byte[]? File { get; set; }
        public DateTime ReleaseDate { get; set; } = DateTime.Now.Date;
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int ProductTypeId { get; set; }
        public virtual ProductType ProductType{ get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        
        public virtual ICollection<ProductTags> ProductTags { get; set; }

        public virtual Order Order { get; set; }
        
    }
}
