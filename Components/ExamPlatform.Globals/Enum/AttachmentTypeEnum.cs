using System.Runtime.Serialization;

namespace ExamPlatform.Globals.Enum
{
    [DataContract]
    public enum AttachmentTypeEnum
    {
        [EnumMember]
        Unknown = 0,
        [EnumMember]
        Image = 1,
        [EnumMember]
        Video = 2
    }
}
