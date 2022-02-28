namespace gspark.Service.Features.Tracks.Commands.CreateTrack
{
    using gspark.Domain.Models;
    using MediatR;
    public class CreateTrackCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public byte[] ArtWork { get; set; }
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
        public string Bpm { get; set; } = string.Empty;
        public int SubGenreId { get; set; }
        public string Collaborator { get; set; } = string.Empty;
        public Key Key { get; set; }
        public Tag Tags { get; set; }
        public Genre Genre { get; set; }
    }
}
