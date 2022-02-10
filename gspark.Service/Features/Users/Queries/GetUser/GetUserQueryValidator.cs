namespace gspark.Service.Features.Users.Queries.GetUser
{
    using FluentValidation;

    public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator()
        {
            RuleFor(userGet => userGet.UserId).NotEmpty();
        }
    }
}
