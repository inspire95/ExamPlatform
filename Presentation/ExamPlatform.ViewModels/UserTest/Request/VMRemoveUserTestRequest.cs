using System;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.UserTest.Request
{
    [DataContract]
    public class VMRemoveUserTestRequest
    {
        [DataMember]
        public Guid UserTestId { get; set; }
    }
}
