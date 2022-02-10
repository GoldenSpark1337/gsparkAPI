namespace gspark.Service.Features.Users.Commands.DeleteUser
{
    using MediatR;
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; set; }
    }
}
