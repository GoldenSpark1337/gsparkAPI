namespace gspark.Domain.Models
{
    public class Tag : BaseEntity
    {
        public string TagName { get; set; }
        public virtual ICollection<ProductTags> ProductTags { get; set; }
    }
}
