namespace gspark.Service.Features.Users.Queries.GetUser
{
    using gspark.Service.Common.Exceptions;
    using gspark.Repository;
    using gspark.Domain.Models;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetUserHandler : IRequestHandler<GetUserQuery, User>
    {
        private readonly MarketPlaceContext _context;
        public GetUserHandler(MarketPlaceContext context)
        {
            _context = context;
        }


        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users.FindAsync(request.UserId);

            if (entity == null || entity.Id != request.UserId)
            {
                throw new NotFoundException(nameof(entity), entity.Id);
            }
            return entity;
        }
    }
}
