namespace gspark.Service.Features.Tracks.Commands.DeleteTrack
{
    using gspark.Repository;
    using gspark.Service.Common.Exceptions;
    using gspark.Tracks.Commands.DeleteTrack;
    using MediatR;

    public class DeleteTrackCommandHandler : IRequestHandler<DeleteTrackCommand>
    {
        private MarketPlaceContext _dbContext { get; }
        public DeleteTrackCommandHandler(MarketPlaceContext context)
        {
            _dbContext = context;
        }

        public async Task<Unit> Handle(DeleteTrackCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Tracks.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.Id != request.Id) throw new NotFoundException(nameof(entity), entity.Id);

            _dbContext.Tracks.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
