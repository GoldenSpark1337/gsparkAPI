namespace gspark.Domain.Models;

public class UserProductLike
{
    public User User { get; set; } // User that liking other product
    public int UserId { get; set; }
    public Product Product { get; set; } // Liked product
    public int ProductId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}