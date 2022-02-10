namespace gspark.Domain.Models
{
    public class Subgenre : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
