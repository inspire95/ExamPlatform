using System;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.UserTest.Request
{
    [DataContract]
    public class VMFinishUserTestRequest
    {
        [DataMember]
        public Guid UserTestId { get; set; }
        [DataMember]
        public DateTime? EndDate { get; set; }
    }
}
