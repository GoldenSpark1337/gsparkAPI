namespace gspark.Domain.Models
{
    public class Subgenre : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
