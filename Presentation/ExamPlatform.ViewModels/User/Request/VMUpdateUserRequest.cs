using System;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.User.Request
{
    [DataContract]
    public class VMUpdateUserRequest : VMCreateUserRequest
    {
        [DataMember]
        public Guid UserId { get; set; }
    }
}
