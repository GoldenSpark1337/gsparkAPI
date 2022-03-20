#nullable disable
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using gspark.API.Controllers;
using gspark.Service.Dtos.UserDtos;
using gspark.Service.Features.Users.Commands.UpdateUser;
using gspark.Service.Features.Users.Commands.UpdateUserInfo;
using gspark.Service.Features.Users.Commands.DeleteUser;
using gspark.Domain.Models;
using gspark.Service.Common.Exceptions;
using gspark.Service.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace gspark.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserRepository _repo;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;

        public UsersController(
            IUserRepository repo, 
            IMediator mediator, 
            IMapper mapper, 
            ILogger<UsersController> logger,
            UserManager<User> userManager, 
            SignInManager<User> signInManager,
            ITokenService tokenService)
        {
            _repo = repo;
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        
        [Authorize(Policy = "AdminRole")]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DtoReturnUser>>> GetAllUsersAsync(CancellationToken cts)
        {
            var users = await _repo.GetAllUsersAsync();
            return Ok(_mapper.Map<IReadOnlyList<DtoReturnUser>>(users));
        }

        [HttpGet("musicians")]
        public async Task<ActionResult<IReadOnlyList<DtoReturnMusician>>> GetAllMusicians()
        {
            var users = await _repo.GetAllUsersAsync();
            return Ok(_mapper.Map<IReadOnlyList<DtoReturnMusician>>(users));
        }

        [Authorize(Roles = "Free, Admin")]
        [HttpGet("account")]
        public async Task<DtoUser> GetCurrentUser()
        {
            // var email = User.FindFirstValue(ClaimTypes.Email); // Much cleaner code option
            var email = HttpContext.User?.Claims?
                .FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value;
            var user = await _userManager.FindByEmailAsync(email);
            var returnUser = _mapper.Map<DtoUser>(user);
            returnUser.Token = await _tokenService.CreateToken(user);
            return returnUser;
        }
        
        [HttpGet("emailexists")]
        public async Task<bool> CheckEmailExistsAsync([FromQuery]string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        [HttpGet("usernameexists")]
        public async Task<bool> CheckUsernameExistsAsync([FromQuery] string username)
        {
            return await _userManager.FindByNameAsync(username) != null;
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<DtoReturnMusician>> GetUserByUsernameAsync(string username)
        {
            var user = await _repo.GetUserByName(username);
            return Ok(_mapper.Map<DtoReturnMusician>(user));
        }

        [HttpPost("register")]
        public async Task<ActionResult<DtoUser>> AddUserAsync(DtoCreateUser createUserDto, CancellationToken cts)
        {
            if (await CheckUsernameExistsAsync(createUserDto.Username))
                return new BadRequestObjectResult(new ApiValidationErrorResponse
                    {Errors = new[] {"Username is already taken"}});
            
            if (await CheckEmailExistsAsync(createUserDto.Email))
                return new BadRequestObjectResult(new ApiValidationErrorResponse
                    {Errors = new[] {"Email address is in use"}});
            
            var user = _mapper.Map<User>(createUserDto);
            user.UserName = createUserDto.Username.ToLower();
            var result = await _userManager.CreateAsync(user, createUserDto.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "Free");
            if (!roleResult.Succeeded) return BadRequest(result.Errors);
            
            var returnUser = _mapper.Map<DtoUser>(user);
            returnUser.Token = await _tokenService.CreateToken(user);
            return returnUser;
        }

        [HttpPost("login")]
        public async Task<ActionResult<DtoUser>> LoginUserAsync([FromBody] DtoLoginUser loginuserDto, CancellationToken cts)
        {
            var user = await _userManager.FindByEmailAsync(loginuserDto.Email);
            if (user == null) return Unauthorized(new ApiResponse(401));

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginuserDto.Password, false);
            if (!result.Succeeded) return Unauthorized(new ApiResponse(401));

            var returnUser = _mapper.Map<DtoUser>(user);
            returnUser.Token = await _tokenService.CreateToken(user);
            return returnUser;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddFile(IFormFile file)
        {
            return Ok();
        }

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
            //TODO
            return Ok(await _mediator.Send(updateUserInfo));
        }

        // [Authorize]
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


