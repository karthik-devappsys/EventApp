
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EventManageApp.Data.Entities.Base;

namespace EventManageApp.Data.Entities
{
    public enum EventStatus
    {
        [EnumMember(Value = "Active")]
        Active,

        [EnumMember(Value = "Inactive")]
        Inactive,

        [EnumMember(Value = "Suspended")]
        Suspended,

        [EnumMember(Value = "Completed")]
        Completed,

        [EnumMember(Value = "Cancelled")]
        Cancelled,

        [EnumMember(Value = "Deleted")]
        Deleted
    }

    public class Events : SoftDelete
    {

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public int TotalSlots { get; set; } = 0;

        [Required]
        public int AvailableSlots { get; set; } = 0;

        [Required, MaxLength(10)]
        public EventStatus Status { get; set; } = EventStatus.Active;

        public ICollection<EventBookings> Bookings { get; set; }

    }
}