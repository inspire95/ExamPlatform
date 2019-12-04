using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Answer.Request
{
    [DataContract]
    public class VMGetAnswerListRequest
    {
        [DataMember]
        public int QuestionId { get; set; }

    }
}
