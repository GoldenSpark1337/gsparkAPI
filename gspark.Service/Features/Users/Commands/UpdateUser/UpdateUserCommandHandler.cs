namespace gspark.Service.Features.Users.Commands.UpdateUser
{
    using gspark.Service.Common.Exceptions;
    using gspark.Repository;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly MarketPlaceContext _context;

        public UpdateUserCommandHandler(MarketPlaceContext context) => _context = context;

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(user => user.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(entity), entity.Id);
            }

            entity.Email = request.Email;
            entity.PasswordHash = request.Password;

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
