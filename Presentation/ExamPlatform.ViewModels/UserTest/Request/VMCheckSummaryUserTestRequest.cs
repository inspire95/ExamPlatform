using System;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.UserTest.Request
{
    [DataContract]
    public class VMCheckSummaryUserTestRequest
    {
        [DataMember]
        public Guid UserTestId { get; set; }
    }
}
