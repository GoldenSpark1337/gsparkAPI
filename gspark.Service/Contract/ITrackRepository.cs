using gspark.Domain.Models;
using gspark.Service.Specification;

namespace gspark.Service.Contract;

public interface ITrackRepository
{
    Task<int> AddTrack(Track track);
    Task DeleteTrack(int id);
}