using gspark.Domain.Identity;

namespace gspark.Service.Contract;

public interface ITokenService
{
    string CreateToken(ApplicationUser user);
}