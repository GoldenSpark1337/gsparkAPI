using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Common.Mappings;

namespace gspark.Dtos.TrackDtos;

public class DtoCreateTrack: IMapWith<Track>
{
    public string Title { get; set; }
    public string? Image { get; set; }
    public byte[]? File { get; set; }
    public DateTime ReleaseDate { get; set; } = DateTime.Now;
    public decimal Price { get; set; }
    // public List<Tag> Tags { get; set; }
    public string Description { get; set; }
    public int ProductTypeId { get; set; }
    public int UserId { get; set; }
    public string Mp3File { get; set; }
    public string? WavFile { get; set; }
    public string Bpm { get; set; } = string.Empty;
    public int TrackKey_Id { get; set; }
    public string Collaborator { get; set; } = string.Empty;
    public int GenreId { get; set; }
    public int SubGenreId { get; set; }

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