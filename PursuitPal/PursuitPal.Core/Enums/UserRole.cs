using System.Runtime.Serialization;

namespace PursuitPal.Core.Enums
{
    public enum UserRole
    {
        [EnumMember(Value = "SystemAdmin")]
        SystemAdmin,
        [EnumMember(Value = "Admin")]
        Admin,
        [EnumMember(Value = "Manager")]
        Manager,
        [EnumMember(Value = "Lead")]
        Lead,
        [EnumMember(Value = "Employee")]
        Employee
    }
}
