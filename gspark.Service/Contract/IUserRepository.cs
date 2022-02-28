using gspark.Domain.Models;
using gspark.Service.Features.Users.Queries.GetUser;

namespace gspark.Service.Contract;

public interface IUserService
{ 
    Task<User> GetUserByIdAsync(int id);
    Task<IReadOnlyList<User>> GetAllUsersAsync();
    Task<int> AddUser(User user);
    Task DeleteUser(int id);
}