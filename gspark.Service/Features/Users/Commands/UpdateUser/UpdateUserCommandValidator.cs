namespace gspark.Service.Features.Users.Commands.UpdateUser
{
    using FluentValidation;

    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(updateUser => updateUser.Email)
                .NotEmpty().WithMessage("Email address is required").MaximumLength(150)
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).WithMessage("A valid email is required");
            RuleFor(updateUser => updateUser.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Passwod must be at least 6 characters");
        }
    }
}
