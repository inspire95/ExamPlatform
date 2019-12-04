using System;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.UserTest.Request
{
    [DataContract]
    public class VMUpdateUserTestRequest : VMCreateUserTestRequest
    {
        [DataMember]
        public Guid UserTestId { get; set; }
    }
}
