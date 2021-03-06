using AutoMapper;
using gspark.Service.Common.Mappings;
using gspark.Service.Features.Users.Commands.UpdateUser;

namespace gspark.Service.Dtos.UserDtos
{
    public class DtoUpdateUserAuth : IMapWith<UpdateUserCommand>
    {
        public string Email { get; set; } = "example@example.com";
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DtoUpdateUserAuth, UpdateUserCommand>()
                .ForMember(userCmd => userCmd.Email,
                    opt => opt.MapFrom(userDto => userDto.Email))
                .ForMember(userCmd => userCmd.Password,
                    opt => opt.MapFrom(userDto => userDto.Password));
        }
    }
}
