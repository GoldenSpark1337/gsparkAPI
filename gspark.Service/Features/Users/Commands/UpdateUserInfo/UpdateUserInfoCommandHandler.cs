namespace gspark.Service.Features.Users.Commands.UpdateUserInfo
{
    using gspark.Service.Common.Exceptions;
    using gspark.Repository;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class UpdateUserInfoCommandHandler : IRequestHandler<UpdateUserInfoCommand>
    {
        private readonly MarketPlaceContext _dbContext;

        public UpdateUserInfoCommandHandler(MarketPlaceContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateUserInfoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(entity), entity.Id);
            }

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Image = request.Image;
            entity.Location = request.Location;
            entity.Biography = request.Biography;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
