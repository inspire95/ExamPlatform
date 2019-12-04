using System.Runtime.Serialization;

namespace ExamPlatform.Globals.Enum
{
    [DataContract]
    public enum UserTestStatusEnum
    {
        [EnumMember]
        Unknown = 0,
        [EnumMember]
        New = 1,
        [EnumMember]
        Pending = 2,
        [EnumMember]
        To_verify = 3,
        [EnumMember]
        Completed = 4
    }
}
