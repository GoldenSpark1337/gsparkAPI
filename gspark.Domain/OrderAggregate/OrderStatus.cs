using System.Runtime.Serialization;

namespace gspark.Domain.OrderAggregate;

public enum OrderStatus
{
    [EnumMember(Value = "Pending")]
    Pending,
    [EnumMember(Value = "Payment received")]
    PaymentReceived,
    [EnumMember(Value = "Payment failed")]
    PaymentFailed
}