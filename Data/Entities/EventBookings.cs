
using System.Runtime.Serialization;

namespace EventManageApp.Data.Entities
{
    public enum BookingStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,

        [EnumMember(Value = "Confirmed")]
        Confirmed,

        [EnumMember(Value = "Cancelled")]
        Cancelled

    }
    public class EventBookings : BaseEntity
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public int Slots { get; set; }
        public decimal Price { get; set; }
        public BookingStatus Status { get; set; } = BookingStatus.Pending;

    }
}