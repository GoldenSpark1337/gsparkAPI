namespace gspark.Domain.Models
{
    public class Tag : IBaseEntity
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public virtual ICollection<ProductTags> ProductTags { get; set; }
    }
}
