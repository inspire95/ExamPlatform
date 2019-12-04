using System.Runtime.Serialization;

namespace ExamPlatform.Globals.Enum
{
    [DataContract]
    public enum TestSummaryTypeEnum
    {
        [EnumMember]
        Unknown = 0,
        [EnumMember]
        Uncompleted = 1,
        [EnumMember]
        Completed_with_pass = 2,
        [EnumMember]
        Completed_with_failure = 3
    }
}
