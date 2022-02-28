using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Common.Mappings;

namespace gspark.Dtos.TrackDtos;

public class DtoReturnTrack : IMapWith<Track>
{
    public string Title { get; set; }
    public string User { get; set; }
    public byte[]? Artwork { get; set; }
    public decimal Price { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Bpm { get; set; }
    public string? Collaborator { get; set; }
    public string Genre { get; set; }
    public string Subgenre { get; set; }
    public string Key { get; set; }
    public int Plays { get; set; } = 0;
    public int Likes { get; set; } = 0;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Track, DtoReturnTrack>()
            .ForMember(dto => dto.User,
                opt => opt.MapFrom(t => t.User.Username))
            .ForMember(dto => dto.Genre,
                opt => opt.MapFrom(t => t.Genre.Name))
            .ForMember(dto => dto.Subgenre,
                opt => opt.MapFrom(t => t.Subgenre.Name))
            .ForMember(dto => dto.Key,
                opt => opt.MapFrom(t => t.Key.Track_Key));
    }
}