using System.Runtime.Serialization;

namespace EventManageApp.Core.Enums
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
}