namespace gspark.Service.Features.Users.Commands.LoginUser
{
    using gspark.Domain.Models;
    using MediatR;

    public class LoginUserCommand : IRequest<User>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
