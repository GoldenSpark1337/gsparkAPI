using AutoMapper;
using gspark.Domain.Models;
using gspark.Dtos.TrackDtos;
using gspark.Service.Common.Mappings;
using gspark.Service.Dtos.ProductDtos;
using File = gspark.Domain.Models.File;

namespace gspark.Service.Dtos.UserDtos;

public class DtoReturnMusician : IMapWith<User>
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Image { get; set; }
    public IList<string> Roles { get; set; }
    public string Location { get; set; }
    public string Biography { get; set; }
    public IReadOnlyList<Playlist> Playlists { get; set; }
    public IReadOnlyList<DtoReturnTrack> Tracks { get; set; }
    public IReadOnlyList<Kit> Kits { get; set; }
    public IReadOnlyList<Domain.Models.Service> Services { get; set; }
    public IReadOnlyList<DtoReturnProduct> Products { get; set; }
    public List<File> Files { get; set; }
    public string RecordLabel { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, DtoReturnMusician>()
            .ForMember(dto => dto.Image,
                opt => opt.MapFrom<UrlResolver<User, DtoReturnMusician>>())
            // .ForMember(dto => dto.Roles,
            //     opt => opt.MapFrom(u =>
            //         u.UserRoles.Where(user => user.User.UserName == u.UserName).Select(ur => ur.Role.Name)))
            .ForMember(dto => dto.RecordLabel,
                opt => opt.MapFrom(u => u.RecordLabel.Name))
            .ForMember(dto => dto.Playlists,
                opt => opt.MapFrom(u => u.Playlists))
            // .ForMember(dto => dto.Tracks,
            //     opt => opt.MapFrom(u => u.Tracks))
            // .ForMember(dto => dto.Kits,
            //     opt => opt.MapFrom(u => u.Kits))
            // .ForMember(dto => dto.Services,
            //     opt => opt.MapFrom(u => u.Services))
            .ForMember(dto => dto.Products,
                opt => opt.MapFrom(u => u.Products));
    }
}