namespace gspark.Service.Features.Users.Commands.UpdateUserInfo
{
    using MediatR;

    public class UpdateUserInfoCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[]? Image { get; set; }
        public string Location { get; set; }
        public string Biography { get; set; }
    }
}
