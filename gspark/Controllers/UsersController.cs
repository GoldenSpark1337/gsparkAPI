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
using gspark.Dtos.TrackDtos;
using gspark.Repository;
using gspark.Service.Common.Exceptions;
using gspark.Service.Contract;
using gspark.Service.Dtos.FileDtos;
using gspark.Service.Dtos.ProductDtos;
using gspark.Service.Specification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using File = gspark.Domain.Models.File;

namespace gspark.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IFileService _fileService;
        private readonly MarketPlaceContext _context;

        public UsersController(
            IUnitOfWork unitOfWork, 
            IMediator mediator, 
            IMapper mapper, 
            ILogger<UsersController> logger,
            UserManager<User> userManager, 
            SignInManager<User> signInManager,
            ITokenService tokenService,
            IFileService fileService,
            MarketPlaceContext context)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _fileService = fileService;
            _context = context;
        }
        
        [Authorize(Policy = "AdminRole")]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DtoReturnUser>>> GetAllUsersAsync(CancellationToken cts)
        {
            var users = await _unitOfWork.UserRepository.GetAllUsersAsync();
            return Ok(_mapper.Map<IReadOnlyList<DtoReturnUser>>(users));
        }

        [HttpGet("musicians")]
        public async Task<ActionResult<IReadOnlyList<DtoReturnMusician>>> GetAllMusicians([FromQuery] UserSpecParams userParams)
        {
            var spec = new UserIncludeSpecification(userParams);
            var users = await _unitOfWork.Repository<User>().ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<DtoReturnMusician>>(users));
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

        [HttpGet("{username}", Name = "GetUsername")]
        public async Task<ActionResult<DtoReturnMusician>> GetUserByUsernameAsync(string username)
        {
            var user = await _unitOfWork.UserRepository.GetUserByName(username);
            var userRoles = await _userManager.GetRolesAsync(user);
            DtoReturnMusician dto = new DtoReturnMusician() {Roles = userRoles};
            return Ok(_mapper.Map(user, dto));
        }

        [HttpGet("{username}/tracks")]
        public async Task<ActionResult<IReadOnlyList<DtoReturnTrack>>> GetUserTracks(string username, bool isDraft = false)
        {
            var tracks = await _unitOfWork.UserRepository.GetUserTracks(username, isDraft);
            return Ok(tracks);
        }

        [HttpGet("{username}/plays")]
        public async Task<ActionResult<int>> GetUserPlays(string username)
        {
            return Ok(await _unitOfWork.TrackRepository.CountPlays(username));
        } 

        [HttpGet("{username}/products")]
        public async Task<ActionResult<IReadOnlyList<DtoReturnProduct>>> GetUserProducts(string username, bool isDraft = false)
        {
            var products = await _unitOfWork.UserRepository.GetUserProducts(username, isDraft);
            return Ok(products);
        }

        [HttpGet("{username}/stats/{period}")]
        public async Task<ActionResult<DtoReturnUserQuickStats>> GetUserQuickStats(string username, string period)
        {
            return Ok(await _unitOfWork.UserRepository.GetUserQuickStats(username, period));
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

        [HttpPost("add-image")]
        public async Task<ActionResult<DtoRetunFile>> AddImage(IFormFile file)
        {
            var username = User.FindFirstValue(ClaimTypes.GivenName);
            var user = await _unitOfWork.UserRepository
                .GetUserByName(username);
            var result = await _fileService.AddImageAsync(file);
            if (result.Error != null) return BadRequest(result.Error.Message);

            var resultFile = new File()
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId,
                UserId = user.Id
            };

            user.Image = resultFile.Url;
            user.Files.Add(resultFile);
            _unitOfWork.UserRepository.UpdateUser(user);
            if (await _unitOfWork.Complete())
            {
                return CreatedAtRoute("GetUsername", new {username = user.UserName}, _mapper.Map<DtoRetunFile>(resultFile));
            }
            
            return BadRequest("Problem adding image");
        }
        
        [HttpPost("add-file")]
        public async Task<ActionResult> AddFile(IFormFile file)
        {
            var user = await _unitOfWork.UserRepository.GetUserByName(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var result = await _fileService.AddFileAsync(file);
            if (result.Error != null) return BadRequest(result.Error.Message);

            var resultFile = new File()
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            user.Files.Add(resultFile);
            // if (await _unitOfWork.Complete()) return Ok(_mapper.Map<DtoRetunFile>(resultFile));
            
            return BadRequest("Problem adding image");
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateUserAuthAsync(int id,[FromBody] DtoUpdateUserAuth updateUserAuth, CancellationToken cts)
        {
            var command = _mapper.Map<UpdateUserCommand>(updateUserAuth);
            command.Id = id;
            return Ok(await _mediator.Send(command, cts));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserInfo(DtoUpdateUser dtoUpdateUser)
        {
            var user = await _unitOfWork.UserRepository.GetUserByName(User.FindFirstValue(ClaimTypes.GivenName));
            _mapper.Map(dtoUpdateUser, user);
            _unitOfWork.UserRepository.UpdateUser(user);
            
            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Failed updating user");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var command = new DeleteUserCommand { Id = id };
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("delete-image/{imageId}")]
        public async Task<IActionResult> DeleteImage(int imageId)
        {
            var user = await _unitOfWork.UserRepository
                .GetUserByName(User.FindFirstValue(ClaimTypes.GivenName));
            var image = user.Files.FirstOrDefault(x => x.Id == imageId);
            // if (image.PublicId != null)
            // {
            //     var result = await _fileService.DeleteFileAsync(image.PublicId);
            //     if (result.Error != null) return BadRequest(new ApiException(400, result.Error.Message));
            // }
            user.Image = null;
            user.Files.Remove(image);
            _unitOfWork.UserRepository.UpdateUser(user);
            
            if (await _unitOfWork.Complete())
            {
                return Ok();
            }
            return BadRequest("Wtf idk what happened");
        }
    }

    
    
}


