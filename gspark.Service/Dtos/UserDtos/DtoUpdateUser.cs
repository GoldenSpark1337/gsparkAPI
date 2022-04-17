using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Common.Mappings;

namespace gspark.Service.Dtos.UserDtos;

public class DtoUpdateUser : IMapWith<User>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Location { get; set; }
    public string Biography { get; set; }
    public string? RecordLabel { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DtoUpdateUser, User>();
    }
}