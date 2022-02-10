namespace gspark.Domain.Models
{
    public class Key : BaseEntity
    {
        public string TrackKey { get; set; }
        public virtual Track? Track { get; set; }
    }
}
