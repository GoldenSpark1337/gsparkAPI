using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace gspark.Service.Dtos.UserDtos
{
    public class DtoLoginUser
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}
