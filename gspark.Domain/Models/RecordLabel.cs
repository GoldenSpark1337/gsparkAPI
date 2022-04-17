namespace gspark.Domain.Models
{
    public class RecordLabel : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Founder { get; set; }

        public virtual ICollection<User>? Users { get; set; }
    }
}
