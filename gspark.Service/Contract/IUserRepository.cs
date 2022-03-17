using gspark.Domain.Models;
using gspark.Service.Features.Users.Queries.GetUser;

namespace gspark.Service.Contract;

public interface IUserRepository
{ 
    Task<IReadOnlyList<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(int id);
    Task<User> GetUserByName(string username);
    Task<int> AddUser(User user);
    Task DeleteUser(int id);
}