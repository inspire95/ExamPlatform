using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Answer.Request
{
    [DataContract]
    public class VMCreateAnswerRequest
    {
        [DataMember]
        public string Content { get; set; }
        [DataMember]
        public int Points { get; set; }
        [DataMember]
        public int QuestionId { get; set; }
        [DataMember]
        public bool IsCorrect { get; set; }
    }
}
