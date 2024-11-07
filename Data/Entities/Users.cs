using System.ComponentModel.DataAnnotations;
using EventManageApp.Core.Enums;
using EventManageApp.Data.Entities.Base;

namespace EventManageApp.Data.Entities
{
    public class Users : SoftDelete
    {

        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(5)]
        public UserType UserType { get; set; } = UserType.User;

        [Required, Phone, MaxLength(10)]
        public string Contact { get; set; } = string.Empty;

        [Required, EmailAddress, MaxLength(360)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required, MaxLength(10)]
        public UserStatus Status { get; set; } = UserStatus.Pending;
        public ICollection<EventBookings> Bookings { get; set; }

    }
}