namespace gspark.Service.Features.Users.Commands.CreateUser
{
    using gspark.Domain.Models;
    using gspark.Repository;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly MarketPlaceContext _context;
        public CreateUserCommandHandler(MarketPlaceContext context) => _context = context;

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new User
            {
                Username = request.UserName,
                Email = request.Email,
                Password = request.Password
            };

            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
