using gspark.Domain.Models;

namespace gspark.Service.Specification.Messages;

public class MessageWithSpecification : BaseSpecification<Message>
{
    public MessageWithSpecification(MessageSpecParams messageParams)
    {
        ApplyPaging(messageParams.PageSize * (messageParams.PageIndex - 1), messageParams.PageSize);
    }
}