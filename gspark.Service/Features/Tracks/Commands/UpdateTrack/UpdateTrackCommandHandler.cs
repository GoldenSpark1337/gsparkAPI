namespace gspark.Tracks.Commands.UpdateTrack
{
    using gspark.Service.Common.Exceptions;
    using gspark.Repository;
    using gspark.Service.Features.Tracks.Commands.UpdateTrack;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class UpdateTrackCommandHandler : IRequestHandler<UpdateTrackCommand>
    {
        private MarketPlaceContext _context { get; }
        public UpdateTrackCommandHandler(MarketPlaceContext context)
        {
            _context = context;
        }


        public async Task<Unit> Handle(UpdateTrackCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Tracks.FirstOrDefaultAsync(track => track.Id == request.Id);
            int i = 0;
            
            if (entity == null || entity.Id != request.Id) throw new NotFoundException(nameof(entity), entity.Id);

            entity.Title = request.Title;
            entity.Artwork = request.ArtWork;
            entity.Key = request.Key;
            entity.Bpm = request.Bpm;
            entity.Genre = request.Genre;
            entity.SubGenre = request.SubGenre;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
