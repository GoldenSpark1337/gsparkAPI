using gspark.Domain.Models;
using gspark.Dtos.TrackDtos;
using gspark.Service.Dtos.ProductDtos;

namespace gspark.Service.Contract;

public interface IUserRepository
{ 
    Task<IReadOnlyList<User>> GetAllUsersAsync();
    // Task<DtoReturnMusician> GetUserByIdAsync(int id);
    Task<User> GetUserByName(string username);
    Task<IReadOnlyList<DtoReturnProduct>> GetUserProducts(string username);
    Task<IReadOnlyList<DtoReturnTrack>> GetUserTracks(string username);
    Task<int> AddUser(User user);
    void UpdateUser(User user);
    Task DeleteUser(int id);
    
}