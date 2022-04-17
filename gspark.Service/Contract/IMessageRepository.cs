using gspark.Domain.Models;
using gspark.Service.Common.Pagination;
using gspark.Service.Dtos.MessageDtos;
using gspark.Service.Specification.Messages;

namespace gspark.Service.Contract;

public interface IMessageRepository
{
    Task AddMessageAsync(Message message);
    void DeleteMessage(Message message);
    Task<Message> GetMessage(int id);
    Task<IQueryable<DtoMessage>> GetMessagesForUser(MessageSpecParams messageParams);
    Task<IReadOnlyList<DtoMessage>> GetLastMessagesForUser(string currentUsername);
    Task<IEnumerable<DtoMessage>> GetMessageThread(string currentUsername, string recipientUsername);
}