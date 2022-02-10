namespace gspark.Service.Features.Users.Queries.GetAllUsers
{
    using gspark.Repository;
    using gspark.Domain.Models;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private MarketPlaceContext _db;

        public GetAllUsersHandler(MarketPlaceContext db)
        {
            _db = db;
        }

        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _db.Users.ToListAsync(cancellationToken);
        }
    }
}
