namespace gspark.Service.Features.Users.Queries.GetAllUsers
{
    using gspark.Domain.Models;
    using MediatR;

    public class GetAllUsersQuery : IRequest<List<User>>
    {

    }
}
