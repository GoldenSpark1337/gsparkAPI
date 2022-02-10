namespace gspark.Models
{
    using AutoMapper;
    using gspark.Service.Common.Mappings;
    using gspark.Service.Features.Users.Commands.CreateUser;

    public class DtoCreateUser : IMapWith<CreateUserCommand>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DtoCreateUser, CreateUserCommand>()
                .ForMember(userCmd => userCmd.UserName,
                    opt => opt.MapFrom(userDto => userDto.Username))
                .ForMember(userCmd => userCmd.Email,
                    opt => opt.MapFrom(userDto => userDto.Email))
                .ForMember(userCmd => userCmd.Password,
                    opt => opt.MapFrom(userDto => userDto.Password))
                .ForMember(userCmd => userCmd.ConfirmPassword,
                    opt => opt.MapFrom(userDto => userDto.ConfirmPassword));
        }
    }
}
