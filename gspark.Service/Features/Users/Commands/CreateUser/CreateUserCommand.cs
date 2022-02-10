namespace gspark.Service.Features.Users.Commands.CreateUser
{
    using MediatR;
    public class CreateUserCommand : IRequest<int>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
