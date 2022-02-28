using AutoMapper;

namespace gspark.Service.Features.Tracks.Commands.CreateTrack
{
    using gspark.Repository;
    using gspark.Domain.Models;
    using MediatR;

    public class CreateTrackCommandHandler : IRequestHandler<CreateTrackCommand, int>
    {
        private readonly IMapper _mapper;
        private MarketPlaceContext _context { get; }
        public CreateTrackCommandHandler(MarketPlaceContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }


        public async Task<int> Handle(CreateTrackCommand request, CancellationToken cancellationToken)
        {
            
            Track track = new Track
            {
                Id = request.Id,
                // UserId = request.UserId,
                // Artwork = request.ArtWork,
                // Title = request.Title,
                // ReleaseDate = request.ReleaseDate,
                Bpm = request.Bpm,
            
                Key = request.Key,
                Collaborator = request.Collaborator,
                Genre = request.Genre,
                SubGenreId = request.SubGenreId,
            };

            await _context.Tracks.AddAsync(track, cancellationToken);
            await _context.SaveChangesAsync();
            
            return track.Id;

        }
    }
}
