namespace gspark.Domain.Models
{
    public class Genre : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public virtual ICollection<Subgenre> Subgenres { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
