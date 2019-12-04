using System;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.UserTestAnswer.Request
{
    [DataContract]
    public class VMGetUserTestAnswerListRequest
    {
        [DataMember]
        public Guid UserTestId { get; set; }
    }
}
