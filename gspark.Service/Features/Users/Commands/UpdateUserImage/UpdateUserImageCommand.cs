namespace gspark.Service.Features.Users.Commands.UpdateUserImage
{
    using MediatR;
    using Microsoft.AspNetCore.Http;

    public class UpdateUserImageCommand : IRequest
    {
        public IFormFile File { get; set; }
    }
}
