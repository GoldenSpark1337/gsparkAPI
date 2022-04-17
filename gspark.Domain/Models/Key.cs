namespace gspark.Domain.Models
{
    public class Key : IBaseEntity
    {
        public int Id { get; set; }
        public string? Track_Key { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
