using AutoMapper;
using gspark.Domain.Identity;
using gspark.Service.Common.Mappings;

namespace gspark.API.Dtos.UserDtos;

public class DtoUser : IMapWith<ApplicationUser>
{
    public string Email { get; set; }
    public string DisplayName { get; set; }
    public string Token { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ApplicationUser, DtoUser>();
    }
}