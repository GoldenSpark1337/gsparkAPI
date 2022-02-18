namespace gspark.Domain.Models
{
    public class Key : BaseEntity
    {
        public string? Track_Key { get; set; }
        public virtual Track Track { get; set; }
    }
}
