using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Answer.Request
{
    [DataContract]
    public class VMGetAnswerDetailsRequest
    {
        [DataMember]
        public int AnswerId { get; set; }
    }
}
