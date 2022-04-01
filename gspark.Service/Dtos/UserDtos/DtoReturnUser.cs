using AutoMapper;
using gspark.Domain.Models;
using gspark.Dtos.TrackDtos;
using gspark.Service.Common.Mappings;
using File = gspark.Domain.Models.File;

namespace gspark.Service.Dtos.UserDtos;

public class DtoReturnUser : IMapWith<User>
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Image { get; set; }
    public string Location { get; set; }
    public string Biography { get; set; }
    public IReadOnlyList<Playlist> Playlists { get; set; }
    public IReadOnlyList<DtoReturnTrack> Tracks { get; set; }
    public IReadOnlyList<Kit> Kits { get; set; }
    public IReadOnlyList<Domain.Models.Service> Services { get; set; }
    public IReadOnlyList<File> Files { get; set; }
    public string RecordLabel { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, DtoReturnUser>()
            .ForMember(dto => dto.Image,
                opt => opt.MapFrom<UrlResolver<User, DtoReturnUser>>())
            .ForMember(dto => dto.Password,
                opt => opt.MapFrom(u => u.PasswordHash))
            .ForMember(dto => dto.RecordLabel,
                opt => opt.MapFrom(u => u.RecordLabel.Name))
            .ForMember(dto => dto.Playlists,
                opt => opt.MapFrom(u => u.Playlists))
            .ForMember(dto => dto.Files,
                opt => opt.MapFrom(u => u.Files));
        profile.CreateMap<User, User>();
    }
}