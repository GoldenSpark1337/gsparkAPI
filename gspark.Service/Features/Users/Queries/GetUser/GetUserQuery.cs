namespace gspark.Service.Features.Users.Queries.GetUser
{
    using gspark.Domain.Models;
    using MediatR;

    public class GetUserQuery : IRequest<User>
    {
        public int UserId { get; set; }
    }
}
