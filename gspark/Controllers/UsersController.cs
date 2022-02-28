#nullable disable
using NLog;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using gspark.Models;
using AutoMapper;
using gspark.Service.Features.Users.Queries.GetAllUsers;
using gspark.Service.Features.Users.Queries.GetUser;
using gspark.Service.Features.Users.Commands.CreateUser;
using gspark.Service.Features.Users.Commands.UpdateUser;
using gspark.Service.Features.Users.Commands.UpdateUserInfo;
using gspark.Service.Features.Users.Commands.DeleteUser;
using Microsoft.AspNetCore.Authorization;
using gspark.Domain.Models;

namespace gspark.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IMediator mediator, IMapper mapper, ILogger<UsersController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync([FromQuery] GetAllUsersQuery query, CancellationToken cts) => Ok(await _mediator.Send(query, cts));

        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserQuery>> GetUserAsync(int id, CancellationToken cts)
        {
            var query = new GetUserQuery { UserId = id };
            return Ok(await _mediator.Send(query, cts));
        }

        [HttpPost("register")]
        public async Task<IActionResult> AddUserAsync([FromBody] CreateUserCommand createUserDto, CancellationToken cts)
        {
            //var command = _mapper.Map<CreateUserCommand>(createUserDto);
            return Ok(await _mediator.Send(createUserDto, cts));
        }

        //[HttpPost("login")]
        //public async Task<IActionResult> LoginUserAsync([FromBody] DtoLoginUser loginuserDto, CancellationToken cts)
        //{
        //    return Ok(await _mediator.Send(loginuserDto, cts));
        //}

        [HttpPatch]
        public async Task<IActionResult> UpdateUserAuthAsync(int id,[FromBody] DtoUpdateUserAuth updateUserAuth, CancellationToken cts)
        {
            var command = _mapper.Map<UpdateUserCommand>(updateUserAuth);
            command.Id = id;
            return Ok(await _mediator.Send(command, cts));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserInfoAsync(int id,[FromBody] UpdateUserInfoCommand updateUserInfo)
        {
            return Ok(await _mediator.Send(updateUserInfo));
        }

        [Authorize]
        [HttpPut("{id}/image")]
        public async Task<IActionResult> UpdateUserImageAsync(int id, [FromForm] IFormFile file)
        {
            if (file.ContentType.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    return Ok();
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var command = new DeleteUserCommand { Id = id };
            return Ok(await _mediator.Send(command));
        }
    }

    
    
}


