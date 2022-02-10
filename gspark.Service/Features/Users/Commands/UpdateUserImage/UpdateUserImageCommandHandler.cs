namespace gspark.Service.Features.Users.Commands.UpdateUserImage
{
    using gspark.Repository;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateUserImageCommandHandler : IRequestHandler<UpdateUserImageCommand>
    {
        private readonly MarketPlaceContext _dbContext;

        public UpdateUserImageCommandHandler(MarketPlaceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateUserImageCommand request, CancellationToken cancellationToken)
        {

            return Unit.Value;
        }
    }
}
