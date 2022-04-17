using System.Security.Claims;
using gspark.Domain.Models;
using gspark.Extensions;
using gspark.Service.Contract;
using gspark.Service.Dtos.LikeDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gspark.API.Controllers;

[Authorize]
public class LikesController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;

    public LikesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DtoLike>>> GetUserLikes(string predicate, int id)
    {
        var entities = await _unitOfWork.LikesRepository.GetProductLikes(predicate, id);
        return Ok(entities);
    }

    [HttpPost("{id}")]
    public async Task<ActionResult> AddLike(int id)
    {
        var user = await _unitOfWork.UserRepository
            .GetUserByName(User.FindFirstValue(ClaimTypes.GivenName));
        var product = await _unitOfWork.Repository<Track>().GetByIdAsync(id);
        var sourceUser = await _unitOfWork.LikesRepository.GetUserWithLikes(user.Id);

        if (product == null) return NotFound();
        
        var userLike = await _unitOfWork.LikesRepository.GetUserLike(user.Id, product.Id);
        if (userLike != null) BadRequest("You've already like this track");

        userLike = new UserProductLike()
        {
            UserId = user.Id,
            ProductId = product.Id
        };

        sourceUser.Likes.Add(userLike);
        if (await _unitOfWork.Complete()) return Ok();
        return BadRequest("Failed to like user");
    }
    
}