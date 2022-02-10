namespace gspark.Domain.Models
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; } = String.Empty;

        public virtual ICollection<Subgenre> Subgenres { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
