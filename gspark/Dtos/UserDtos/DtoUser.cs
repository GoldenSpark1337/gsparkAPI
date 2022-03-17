using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Common.Mappings;

namespace gspark.API.Dtos.UserDtos;

public class DtoUser : IMapWith<User>
{
    public string Email { get; set; }
    public string DisplayName { get; set; }
    public string Token { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, DtoUser>()
            .ForMember(dto => dto.DisplayName, 
                opt => opt.MapFrom(u => u.UserName));
    }
}