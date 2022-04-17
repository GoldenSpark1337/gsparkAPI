using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace gspark.Domain.Models
{
    public class Product : IBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Image { get; set; }
        public string? File { get; set; }
        public DateTime ReleaseDate { get; set; } = DateTime.Now.Date;
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int ProductTypeId { get; set; }
        public virtual ProductType ProductType{ get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public bool IsDraft { get; set; } = true;
        public List<string> Tags { get; set; } = new List<string>();
        
        public virtual ICollection<ProductTags> ProductTags { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<UserProductLike> Likes { get; set; }

        
    }
}
