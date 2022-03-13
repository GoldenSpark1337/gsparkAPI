using AutoMapper;
using gspark.Models;

namespace gspark.API.Dtos.UserDtos
{
    public class DtoLoginUser
    {
        public string Email { get; set; } = "example@example.com";
        public string Password { get; set; }
    }
}
