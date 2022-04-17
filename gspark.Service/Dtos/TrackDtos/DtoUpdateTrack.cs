using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Common.Mappings;

namespace gspark.Dtos.TrackDtos;

public class DtoUpdateTrack : IMapWith<Track>
{
    public string Title { get; set; }
    public string? Image { get; set; }
    public string File { get; set; }
    public DateTime ReleaseDate { get; set; } = DateTime.Now;
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Mp3File { get; set; }
    public string? WavFile { get; set; }
    public string Bpm { get; set; }
    public int? TrackKey_Id { get; set; }
    public string Collaborator { get; set; }
    public int GenreId { get; set; }
    public int SubGenreId { get; set; }
    public List<string> Tags { get; set; }
    public bool IsDraft { get; set; } = false;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DtoUpdateTrack, Track>();
    }
}