using gspark.Domain.Models;
using gspark.Service.Dtos.UserDtos;
using gspark.Service.Features.Users.Queries.GetUser;

namespace gspark.Service.Contract;

public interface IUserRepository
{ 
    Task<IReadOnlyList<User>> GetAllUsersAsync();
    // Task<DtoReturnMusician> GetUserByIdAsync(int id);
    Task<DtoReturnMusician> GetUserByName(string username);
    Task<int> AddUser(User user);
    Task DeleteUser(int id);
}