
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EventManageApp.Core.Enums;

namespace EventManageApp.Data.Entities
{
    public class EventBookings : BaseEntity
    {
        [Required]
        public Guid BookingId { get; set; } = Guid.NewGuid();

        [Required]
        public int EventId { get; set; }

        public virtual Events Event { get; set; }

        [Required]
        public int UserId { get; set; }

        public Users User { get; set; }

        [Required]
        public int Slots { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public BookingStatus Status { get; set; } = BookingStatus.Pending;
    }
}