using Microsoft.AspNetCore.Http;

namespace gspark.Service.Dtos.FileDtos;

public class DtoCreateImage
{
    public string Url { get; set; }
    public IFormFile File { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string PublicId { get; set; }
}