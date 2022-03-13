using System.ComponentModel.DataAnnotations.Schema;

namespace gspark.Domain.Models
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string? Image { get; set; }
        public byte[]? File { get; set; }
        public DateTime ReleaseDate { get; set; } = DateTime.Now.Date;
        public decimal Price { get; set; }
        [Column(TypeName="json")]
        public string Tags { get; set; }
        public string Description { get; set; }
        public int ProductTypeId { get; set; }
        public virtual ProductType ProductType{ get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int? VstId { get; set; }
        public virtual Vst Vsts { get; set; }
        public int? TrackId { get; set; }
        public virtual Track Tracks { get; set; }

        public virtual Order Order { get; set; }
        
    }
}
