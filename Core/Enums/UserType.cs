using System.Runtime.Serialization;
namespace EventManageApp.Core.Enums
{
    public enum UserType
    {
        [EnumMember(Value = "Admin")]
        Admin,

        [EnumMember(Value = "User")]
        User
    }
}