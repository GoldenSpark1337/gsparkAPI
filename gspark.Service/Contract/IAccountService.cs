using gspark.Domain.Auth;
using gspark.Service.Common.Response;

namespace gspark.Service.Contract
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request);
    }
}
