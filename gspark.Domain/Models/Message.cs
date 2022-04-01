﻿namespace gspark.Domain.Models;

public class Message : BaseEntity
{
    public int SenderId { get; set; }
    public string SenderUsername { get; set; }
    public User Sender { get; set; }
    public int RecipientId { get; set; }
    public string RecipientUsername { get; set; }
    public User Recipient { get; set; }
    public string Content { get; set; }
    public DateTime? DateRead { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public bool SenderDeleted { get; set; }
    public bool RecipientDeleted { get; set; }
}