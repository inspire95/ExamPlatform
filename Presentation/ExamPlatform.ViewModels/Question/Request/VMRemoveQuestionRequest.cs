using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Question.Request
{
    [DataContract]
    public class VMRemoveQuestionRequest
    {
        [DataMember]
        public int QuestionId { get; set; }
    }
}
