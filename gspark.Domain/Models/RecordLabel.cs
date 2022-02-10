namespace gspark.Domain.Models
{
    public class RecordLabel : BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Founder { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
