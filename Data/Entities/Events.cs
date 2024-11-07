using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EventManageApp.Core.Enums;
using EventManageApp.Data.Entities.Base;

namespace EventManageApp.Data.Entities
{
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

        [Required]
        public string ImageUrl { get; set; } = string.Empty;
        public ICollection<EventBookings> Bookings { get; set; }

    }
}