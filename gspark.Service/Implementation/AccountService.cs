using gspark.Domain.Auth;
using gspark.Service.Common.Response;
using gspark.Service.Contract;

namespace gspark.Service.Implementation
{
    public class AccountService : IAccountService
    {
        public Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
