using System;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.UserTestAnswer.Request
{
    [DataContract]
    public class VMGetUserAnswersToQuestionRequest
    {
        [DataMember]
        public Guid UserTestId { get; set; }

        [DataMember]
        public int QuestionId { get; set; }
    }
}
