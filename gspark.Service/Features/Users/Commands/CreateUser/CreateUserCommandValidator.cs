namespace gspark.Service.Features.Users.Commands.CreateUser
{
    using FluentValidation;

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(createUser => createUser.UserName)
                .NotEmpty().WithMessage("Username is required");
            RuleFor(createUser => createUser.Email)
                .NotEmpty().WithMessage("Email address is required").MaximumLength(150)
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).WithMessage("A valid email is required");
            RuleFor(createUser => createUser.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Passwod must be at least 6 characters");
            RuleFor(createUser => createUser.ConfirmPassword).Matches(user => user.Password).WithMessage("Passwords must match");
        }
    }
}
