using System.Runtime.Serialization;

namespace ExamPlatform.Globals.Enum
{
    [DataContract]
    public enum RoleEnum
    {
        [EnumMember]
        Unknown = 0,
        [EnumMember]
        Admin = 1,
        [EnumMember]
        User = 2
    }
}
