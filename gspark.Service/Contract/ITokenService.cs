using gspark.Domain.Models;

namespace gspark.Service.Contract;

public interface ITokenService
{
    Task<string> CreateToken(User user);
}