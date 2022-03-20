using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Common.Mappings;

namespace gspark.Service.Dtos.UserDtos;

public class DtoUser : IMapWith<User>
{
    public string Email { get; set; }
    public string Username { get; set; }
    public string Token { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, DtoUser>()
            .ForMember(dto => dto.Username, 
                opt => opt.MapFrom(u => u.UserName));
    }
}