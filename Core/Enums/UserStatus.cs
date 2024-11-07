using System.Runtime.Serialization;

namespace EventManageApp.Core.Enums
{
    public enum UserStatus
    {
        [EnumMember(Value = "Active")]
        Active,

        [EnumMember(Value = "Suspended")]
        Suspended,

        [EnumMember(Value = "Pending")]
        Pending,

        [EnumMember(Value = "Banned")]
        Banned,

        [EnumMember(Value = "Deleted")]
        Deleted
    }
}