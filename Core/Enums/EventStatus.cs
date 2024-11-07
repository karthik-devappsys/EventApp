
using System.Runtime.Serialization;

namespace EventManageApp.Core.Enums
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
}