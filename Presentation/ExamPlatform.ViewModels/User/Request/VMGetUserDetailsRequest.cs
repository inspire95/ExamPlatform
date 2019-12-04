using System;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.User.Request
{
    [DataContract]
    public class VMGetUserDetailsRequest
    {
        [DataMember]
        public Guid UserId { get; set; }
    }
}
