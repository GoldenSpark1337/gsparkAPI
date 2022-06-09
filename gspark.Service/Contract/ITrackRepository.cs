using gspark.Domain.Models;
using gspark.Service.Specification;

namespace gspark.Service.Contract;

public interface ITrackRepository
{
    Task<int> AddTrack(Track track);
    Task<int> CountPlays(string username);
    Task DeleteTrack(int id);
}