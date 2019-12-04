using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.QuestionType.Request
{
    [DataContract]
    public class VMUpdateQuestionTypeRequest : VMCreateQuestionTypeRequest
    {
        [DataMember]
        public int QuestionTypeId { get; set; }
    }
}