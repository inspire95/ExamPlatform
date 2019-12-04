using System;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.UserTestAnswer.Request
{
    [DataContract]
    public class VMRemoveUserTestAnswerRequest
    {
        [DataMember]
        public int QuestionId { get; set; }

        [DataMember]
        public Guid UserTestId { get; set; }
    }
}
