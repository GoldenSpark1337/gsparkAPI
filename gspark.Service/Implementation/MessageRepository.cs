using AutoMapper;
using AutoMapper.QueryableExtensions;
using gspark.Domain.Models;
using gspark.Repository;
using gspark.Service.Contract;
using gspark.Service.Dtos.MessageDtos;
using gspark.Service.Specification.Messages;
using Microsoft.EntityFrameworkCore;

namespace gspark.Service.Implementation;

public class MessageRepository : IMessageRepository
{
    private readonly MarketPlaceContext _context;
    private readonly IMapper _mapper;

    public MessageRepository(MarketPlaceContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task AddMessageAsync(Message message)
    {
        _context.Messages.Attach(message);
        await _context.Messages.AddAsync(message);
        _context.Entry(message).State = EntityState.Added;
    }

    public void DeleteMessage(Message message)
    {
        _context.Messages.Remove(message);
    }

    public async Task<Message> GetMessage(int id)
    {
        return await _context.Messages.FindAsync(id);
    }

    public async Task<IQueryable<DtoMessage>> GetMessagesForUser(MessageSpecParams messageParams)
    {
        var query = _context.Messages
            .OrderBy(m => m.CreatedAt)
            .AsQueryable();

        query = messageParams.Container switch
        {
            "Inbox" => query.Where(u => u.Recipient.UserName == messageParams.Username),
            "Outbox" => query.Where(u => u.Sender.UserName == messageParams.Username),
            "Unread" => query.Where(u => u.Recipient.UserName == messageParams.Username && u.DateRead == null),
            _ => query.Where(u => u.Recipient.UserName == messageParams.Username || u.Sender.UserName == messageParams.Username)
        };

        var messages = query.ProjectTo<DtoMessage>(_mapper.ConfigurationProvider);
        return messages;
    }

    public async Task<IReadOnlyList<DtoMessage>> GetLastMessagesForUser(string currentUsername)
    {
        var messages = await _context.Messages
            .Include(m => m.Sender).ThenInclude(u => u.Files)
            .Include(m => m.Recipient).ThenInclude(u => u.Files)
            .Where(m => m.RecipientUsername == currentUsername)
            .OrderBy(m => m.CreatedAt)
            .ToListAsync();
        
        
        
        return _mapper.Map<IReadOnlyList<DtoMessage>>(messages);
    }

    public async Task<IEnumerable<DtoMessage>> GetMessageThread(string currentUsername, string recipientUsername)
    {
        var messages = await _context.Messages
            .Include(m => m.Sender).ThenInclude(u => u.Files)
            .Include(m => m.Recipient).ThenInclude(u => u.Files)
            .Where(m => m.Recipient.UserName == currentUsername
                        && m.Sender.UserName == recipientUsername
                        || m.Recipient.UserName == recipientUsername
                        && m.Sender.UserName == currentUsername
            )
            .OrderBy(m => m.CreatedAt)
            .ToListAsync();

        var unreadMessages = messages.Where(m => m.DateRead == null
            && m.Recipient.UserName == currentUsername).ToList();

        if (unreadMessages.Any())
        {
            foreach (var message in unreadMessages)
            {
                message.DateRead = DateTime.Now;
            }

            await _context.SaveChangesAsync();
        }

        return _mapper.Map<IEnumerable<DtoMessage>>(messages);
    }
}