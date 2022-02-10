using gspark.Domain.Identity;
using gspark.Repository;
using gspark.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace gspark.Service.Features.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, User>
    {
        private readonly MarketPlaceContext _dbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginUserCommandHandler(MarketPlaceContext dbContext, SignInManager<ApplicationUser> signInManager)
        {
            _dbContext = dbContext;
            _signInManager = signInManager;
        }

        public async Task<User> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FindAsync(request.Email);

            if (user == null) return null;

            //var result = await _signInManager.CheckPasswordSignInAsync(user, );

            return user;

        }
    }
}
