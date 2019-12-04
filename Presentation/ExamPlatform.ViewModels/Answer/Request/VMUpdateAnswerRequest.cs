using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Answer.Request
{
    [DataContract]
    public class VMUpdateAnswerRequest : VMCreateAnswerRequest
    {
        [DataMember]
        public int AnswerId { get; set; }
    }
}
