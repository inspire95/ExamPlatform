using System;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.UserTestAnswer.Request
{
    [DataContract]
    public class VMCreateUserTestAnswerRequest
    {
        [DataMember]
        public int QuestionId { get; set; }
        [DataMember]
        public int? AnswerId { get; set; }
        [DataMember]
        public Guid UserTestId { get; set; }
        [DataMember]
        public string Content { get; set; }
    }
}