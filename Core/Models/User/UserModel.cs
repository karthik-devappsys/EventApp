using EventManageApp.Core.Enums;

namespace EventManageApp.Core.Models.User
{
    public class UserModel
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserStatus Status { get; set; }
    }
}