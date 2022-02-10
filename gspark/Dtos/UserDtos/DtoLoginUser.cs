using AutoMapper;
using gspark.Models;

namespace gspark.API.Dtos.UserDtos
{
    public class DtoLoginUser /*IMapWith<User>*/
    {
        public string Email { get; set; }
        public string Password { get; set; }

        //public void Mapping(Profile profile)
        //{
        //    profile.CreateMap<User>();
        //}
    }
}
