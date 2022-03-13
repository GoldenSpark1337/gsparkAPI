#nullable disable
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using gspark.Models;
using AutoMapper;
using gspark.API.Controllers;
using gspark.API.Dtos.UserDtos;
using gspark.Domain.Identity;
using gspark.Service.Features.Users.Commands.UpdateUser;
using gspark.Service.Features.Users.Commands.UpdateUserInfo;
using gspark.Service.Features.Users.Commands.DeleteUser;
using gspark.Domain.Models;
using gspark.Service.Common.Exceptions;
using gspark.Service.Contract;
using gspark.Service.Specification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace gspark.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IGenericRepository<User> _repo;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;

        public UsersController(IGenericRepository<User> repo, IMediator mediator, 
            IMapper mapper, ILogger<UsersController> logger,
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
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

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DtoReturnUser>>> GetAllUsersAsync(CancellationToken cts)
        {
            var spec = new UserIncludeSpecification();
            var users = await _repo.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<DtoReturnUser>>(users));
        }

        [Authorize]
        [HttpGet("account")]
        public async Task<DtoUser> GetCurrentUser()
        {
            // var email = User.FindFirstValue(ClaimTypes.Email); // Much cleaner code option
            var email = HttpContext.User?.Claims?
                .FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value;
            var user = await _userManager.FindByEmailAsync(email);
            var returnUser = _mapper.Map<DtoUser>(user);
            returnUser.Token = _tokenService.CreateToken(user);
            return returnUser;
        }
        
        [HttpGet("emailexists")]
        public async Task<bool> CheckEmailExistsAsync([FromQuery]string email)
        {
            return _userManager.FindByEmailAsync(email) != null;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DtoReturnUser>> GetUserAsync(int id, CancellationToken cts)
        {
            var spec = new UserIncludeSpecification(id);
            var user = await _repo.GetEntityWithSpecification(spec);
            return Ok(_mapper.Map<DtoReturnUser>(user));
        }

        [HttpPost("register")]
        public async Task<ActionResult<DtoUser>> AddUserAsync(DtoCreateUser createUserDto, CancellationToken cts)
        {
            var user = _mapper.Map<ApplicationUser>(createUserDto);
            var result = await _userManager.CreateAsync(user, createUserDto.Password);
            if (!result.Succeeded) return BadRequest(new ApiResponse(400));
            
            var returnUser = _mapper.Map<DtoUser>(user);
            returnUser.Token = _tokenService.CreateToken(user);
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
            returnUser.Token = _tokenService.CreateToken(user);
            return returnUser;
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


