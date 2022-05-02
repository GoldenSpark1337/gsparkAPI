using gspark.Domain.Models;
using gspark.Dtos.TrackDtos;
using gspark.Service.Dtos.ProductDtos;
using gspark.Service.Dtos.UserDtos;

namespace gspark.Service.Contract;

public interface IUserRepository
{ 
    Task<IReadOnlyList<User>> GetAllUsersAsync();
    Task<User> GetUserByName(string username);
    Task<IReadOnlyList<DtoReturnProduct>> GetUserProducts(string username, bool isDraft);
    Task<IReadOnlyList<DtoReturnTrack>> GetUserTracks(string username, bool isDraft);
    Task<DtoReturnUserQuickStats> GetUserQuickStats(string username, string period);
    Task<int> AddUser(User user);
    void UpdateUser(User user);
    Task DeleteUser(int id);
    
}