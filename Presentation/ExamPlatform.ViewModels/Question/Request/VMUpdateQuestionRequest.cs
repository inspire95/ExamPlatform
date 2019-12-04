using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Question.Request
{
    [DataContract]
    public class VMUpdateQuestionRequest : VMCreateQuestionRequest
    {
        [DataMember]
        public int QuestionId { get; set; }
    }
}
