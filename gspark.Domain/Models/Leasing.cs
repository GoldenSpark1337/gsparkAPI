namespace gspark.Domain.Models;

public class Leasing
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; } = true;
    public int UserId { get; set; }
    public string Streams { get; set; }
    public string Copies { get; set; }
    public string TrackType { get; set; } = "mp3";

    public User User { get; set; }
}