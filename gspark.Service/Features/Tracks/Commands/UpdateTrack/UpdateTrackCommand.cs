namespace gspark.Service.Features.Tracks.Commands.UpdateTrack
{
    using gspark.Domain.Models;
    using MediatR;

    public class UpdateTrackCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[]? ArtWork { get; set; }
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
        public string Bpm { get; set; } = string.Empty;
        public Key Key { get; set; }
        public string Collaborator { get; set; } = string.Empty;
        public Genre Genre { get; set; }
        public string SubGenre { get; set; } = string.Empty;
    }
}
