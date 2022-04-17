using System.Security.Claims;
using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Common.Exceptions;
using gspark.Service.Common.Pagination;
using gspark.Service.Contract;
using gspark.Service.Dtos.MessageDtos;
using gspark.Service.Dtos.ProductDtos;
using gspark.Service.Specification;
using gspark.Service.Specification.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gspark.API.Controllers;

[Authorize]
[Route("api/messages")]
public class MessageController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MessageController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<DtoMessage>> CreateMessage(DtoCreateMessage dtoCreateMessage)
    {
        var username = User.FindFirstValue(ClaimTypes.GivenName);

        if (username == dtoCreateMessage.RecipientUsername.ToLower()) 
            return BadRequest(new ApiResponse(400, "You cannot sent messages to yourself"));

        var sender = await _unitOfWork.UserRepository.GetUserByName(username);
        var recipient = await _unitOfWork.UserRepository.GetUserByName(dtoCreateMessage.RecipientUsername);

        if (recipient == null) return NotFound();

        var message = new Message
        {
            Sender = sender,
            Recipient = recipient,
            SenderUsername = sender.UserName,
            RecipientUsername = recipient.UserName,
            Content = dtoCreateMessage.Content
        };
        await _unitOfWork.MessageRepository.AddMessageAsync(message);

        if (await _unitOfWork.Complete()) return Ok(_mapper.Map<DtoMessage>(message));
        return BadRequest("Failed to create message");
    }

    [HttpGet]
    public async Task<ActionResult<Pagination<DtoMessage>>> GetMessagesForUser(
        [FromQuery] MessageSpecParams messageParams)
    {
        messageParams.Username = User.FindFirstValue(ClaimTypes.GivenName);
        var spec = new MessageWithSpecification(messageParams);
        var countSpec = new MessageWithCountSpecification(messageParams);
        
        var totalItems = await _unitOfWork.Repository<Message>().CountAsync(countSpec);
        var entities = await _unitOfWork.MessageRepository.GetMessagesForUser(messageParams);
        var data = _mapper.Map<IReadOnlyList<DtoMessage>>(entities);
        
        return Ok(new Pagination<DtoMessage>(messageParams.PageIndex, 
            messageParams.PageSize, totalItems, data));
    }

    [HttpGet("last")]
    public async Task<ActionResult<IReadOnlyList<DtoMessage>>> GetLastMessages()
    {
        var currentUser = User.FindFirstValue(ClaimTypes.GivenName);
        return Ok(await _unitOfWork.MessageRepository.GetLastMessagesForUser(currentUser));
    }

    [HttpGet("thread/{username}")]
    public async Task<ActionResult<IEnumerable<DtoMessage>>> GetMessageThread(string username)
    {
        var currentUser = User.FindFirstValue(ClaimTypes.GivenName);
        return Ok(await _unitOfWork.MessageRepository.GetMessageThread(currentUser, username));
    }
}