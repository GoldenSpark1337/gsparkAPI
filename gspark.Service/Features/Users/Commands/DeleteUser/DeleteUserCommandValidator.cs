namespace gspark.Service.Features.Users.Commands.DeleteUser
{
    using FluentValidation;

    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(userDelete => userDelete.Id).NotEmpty();
        }
    }
}
