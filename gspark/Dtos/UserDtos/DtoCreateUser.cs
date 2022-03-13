using gspark.Domain.Identity;

namespace gspark.Models
{
    using AutoMapper;
    using gspark.Service.Common.Mappings;
    using gspark.Service.Features.Users.Commands.CreateUser;

    public class DtoCreateUser : IMapWith<ApplicationUser>
    {
        public string Username { get; set; }
        public string Email { get; set; } = "example@example.com";
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DtoCreateUser, ApplicationUser>()
                .ForMember(appUser => appUser.DisplayName,
                    opt => opt.MapFrom(userDto => userDto.Username))
                .ForMember(appUser => appUser.Email,
                    opt => opt.MapFrom(userDto => userDto.Email));
        }
    }
}
