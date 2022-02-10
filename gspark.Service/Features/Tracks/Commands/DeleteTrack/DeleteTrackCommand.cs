using MediatR;

namespace gspark.Tracks.Commands.DeleteTrack
{
    public class DeleteTrackCommand : IRequest
    {
        public int Id { get; set; }
    }
}
