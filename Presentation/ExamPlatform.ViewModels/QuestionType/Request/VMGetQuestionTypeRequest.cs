using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.QuestionType.Request
{
    [DataContract]
    public class VMGetQuestionTypeRequest
    {
        [DataMember]
        public int QuestionTypeId { get; set; }
    }
}