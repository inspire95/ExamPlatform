using System.Runtime.Serialization;

namespace ExamPlatform.Globals.Enum
{
    [DataContract]
    public enum QuestionTypeEnum
    {
        [EnumMember]
        Unknown = 0,

        [EnumMember]
        CheckBox = 1,

        [EnumMember]
        RadioButton = 2,

        [EnumMember]
        TextBox = 3
    }
}
