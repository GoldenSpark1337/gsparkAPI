using System.ComponentModel.DataAnnotations;
using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Common.Mappings;

namespace gspark.Service.Dtos.UserDtos
{
    public class DtoCreateUser : IMapWith<User>
    {
        [Required]
        [MinLength(3)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=[^\d_].*?\d)\w(\w|[!@#$%]){7,20}", 
            ErrorMessage = "Password length must be at least than 8 and contain alphanumeric characters")]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DtoCreateUser, User>()
                .ForMember(appUser => appUser.UserName,
                    opt => opt.MapFrom(userDto => userDto.Username))
                .ForMember(appUser => appUser.Email,
                    opt => opt.MapFrom(userDto => userDto.Email));
        }
    }
}
