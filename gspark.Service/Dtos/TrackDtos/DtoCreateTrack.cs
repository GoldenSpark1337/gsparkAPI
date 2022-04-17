using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Common.Mappings;

namespace gspark.Dtos.TrackDtos;

public class DtoCreateTrack: IMapWith<Track>
{
    public string Title { get; set; } = "New Track";
    public string? Image { get; set; }
    public string? File { get; set; }
    public DateTime ReleaseDate { get; set; } = DateTime.Now;

    public decimal Price { get; set; } = 1;
    public string Description { get; set; } = string.Empty;
    public int ProductTypeId { get; set; } = 1;
    public int UserId { get; set; }
    public string Mp3File { get; set; } = string.Empty;
    public string? WavFile { get; set; }
    public string Bpm { get; set; } = "1";
    public int? TrackKey_Id { get; set; }
    public string Collaborator { get; set; } = string.Empty;
    public int GenreId { get; set; } = 1;
    public int SubGenreId { get; set; } = 1;
    public List<string> Tags { get; set; } = new List<string>() {""};

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DtoCreateTrack, Track>()
            .ForMember(track => track.GenreId,
                opt => opt.MapFrom(trackDto => trackDto.GenreId))
            .ForMember(track => track.Bpm,
                opt => opt.MapFrom(trackDto => trackDto.Bpm))
            .ForMember(track => track.TrackKey_Id,
                opt => opt.MapFrom(trackDto => trackDto.TrackKey_Id))
            .ForMember(track => track.Collaborator,
                opt => opt.MapFrom(trackDto => trackDto.Collaborator))
            .ForMember(track => track.SubGenreId,
                opt => opt.MapFrom(trackDto => trackDto.SubGenreId));
    }
}