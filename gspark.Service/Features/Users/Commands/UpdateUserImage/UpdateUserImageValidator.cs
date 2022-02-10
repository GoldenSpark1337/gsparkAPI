namespace gspark.Service.Features.Users.Commands.UpdateUserImage
{
    using FluentValidation;

    public class UpdateUserImageValidator : AbstractValidator<UpdateUserImageCommand>
    {
        private readonly string[] _allowedExtensions = { ".jpg", ".png", ".jpeg" };
        public UpdateUserImageValidator()
        {
            RuleFor(file => file.File)
                .NotEmpty()
                .Must(file => _allowedExtensions.Contains(Path.GetExtension(file.FileName)))
                .WithMessage("Allowed type for file is \"jpg\", \"png\", \"jpeg\"");
        }
    }
}
