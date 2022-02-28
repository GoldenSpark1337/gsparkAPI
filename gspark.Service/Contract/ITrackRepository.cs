using gspark.Domain.Models;

namespace gspark.Service.Contract;

public interface ITrackRepository
{
    Task<Track> GetTrackAsync(int id);
    Task<IReadOnlyList<Track>> GetAllTracksAsync();
    Task<int> AddTrack(Track track);
    Task DeleteTrack(int id);
}