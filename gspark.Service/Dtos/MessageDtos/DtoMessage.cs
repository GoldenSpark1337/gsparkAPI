using AutoMapper;
using gspark.Domain.Models;
using gspark.Service.Common.Mappings;

namespace gspark.Service.Dtos.MessageDtos;

public class DtoMessage : IMapWith<Message>
{
    public int Id { get; set; }
    public int SenderId { get; set; }
    public string SenderUsername { get; set; }
    public string SenderImage { get; set; }
    public int RecipientId { get; set; }
    public string RecipientUsername { get; set; }
    public string RecipientImage { get; set; }
    public string Content { get; set; }
    public DateTime? DateRead { get; set; }
    public DateTime CreatedAt { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Message, DtoMessage>()
            .ForMember(dto => dto.SenderImage, 
                opt => opt.MapFrom(m => m.Sender.Image))
            .ForMember(dto => dto.RecipientImage, 
                opt => opt.MapFrom(m => m.Recipient.Image));
    }
}