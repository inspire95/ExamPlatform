using System;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.UserTest.Request
{
    [DataContract]
    public class VMStartUserTestRequest
    {
        [DataMember]
        public Guid UserTestId { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }
    }
}

