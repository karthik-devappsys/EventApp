
using System.ComponentModel.DataAnnotations;
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
        public decimal Price { get; set; }

        [Required]
        public int Slots { get; set; } = 0;

        [Required, MaxLength(10)]
        public EventStatus Status { get; set; } = EventStatus.Active;

    }
}