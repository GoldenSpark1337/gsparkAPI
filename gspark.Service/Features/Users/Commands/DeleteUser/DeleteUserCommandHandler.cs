namespace gspark.Service.Features.Users.Commands.DeleteUser
{
    using gspark.Service.Common.Exceptions;
    using gspark.Repository;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly MarketPlaceContext _dbContext;

        public DeleteUserCommandHandler(MarketPlaceContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.Id != request.Id) throw new NotFoundException(nameof(entity), entity.Id);

            _dbContext.Users.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
