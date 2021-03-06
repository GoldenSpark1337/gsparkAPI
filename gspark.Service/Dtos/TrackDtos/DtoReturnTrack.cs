using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Common.Mappings;

namespace gspark.Dtos.TrackDtos;

public class DtoReturnTrack : IMapWith<Product>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Image { get; set; }
    public string? File { get; set; }
    public string? DeliveryUrl { get; set; }
    public DateTime ReleaseDate { get; set; }
    public decimal Price { get; set; }
    // public List<Tag> Tags { get; set; }
    public string Description { get; set; }
    public string Mp3File { get; set; }
    public string? WavFile { get; set; }
    public string Bpm { get; set; }
    public string Collaborator { get; set; }
    public string ProductType { get; set; } = "tracks";
    
    public string User { get; set; }
    public string Genre { get; set; }
    public string Subgenre { get; set; }
    public string Key { get; set; }
    public bool IsDraft { get; set; }
    public int Plays { get; set; } = 0;
    public int Likes { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, DtoReturnTrack>()
            .ForMember(dto => dto.User,
                opt => opt.MapFrom(t => t.User.UserName));

        profile.CreateMap<Track, DtoReturnTrack>()
            .ForMember(dto => dto.User,
                opt => opt.MapFrom(t => t.User.UserName))
            .ForMember(dto => dto.Image,
                opt => opt.MapFrom(t => t.User.Image))
            .ForMember(dto => dto.Genre,
                opt => opt.MapFrom(t => t.Genre.Name))
            .ForMember(dto => dto.Subgenre,
                opt => opt.MapFrom(t => t.Subgenre.Name))
            .ForMember(dto => dto.Key,
                opt => opt.MapFrom(t => t.Key.Track_Key))
            .ForMember(dto => dto.Bpm,
                opt => opt.MapFrom(t => t.Bpm))
            .ForMember(dto => dto.ProductType,
                opt => opt.MapFrom(t => "Tracks"))
            .ForMember(dto => dto.Likes,
                opt => opt.MapFrom(t => t.Likes));
    }
}