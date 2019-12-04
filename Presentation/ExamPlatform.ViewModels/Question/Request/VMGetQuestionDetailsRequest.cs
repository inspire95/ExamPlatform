using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Question.Request
{
    [DataContract]
    public class VMGetQuestionDetailsRequest
    {
        [DataMember]
        public int QuestionId { get; set; }
    }
}

