using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.QuestionType.Request
{
    [DataContract]
    public class VMRemoveQuestionTypeRequest
    {
        [DataMember]
        public int QuestionTypeId { get; set; }
    }
}