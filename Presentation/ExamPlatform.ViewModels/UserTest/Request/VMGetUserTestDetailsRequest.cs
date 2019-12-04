using System;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.UserTest.Request
{
    [DataContract]
    public class VMGetUserTestDetailsRequest
    {
        [DataMember]
        public Guid UserTestId { get; set; }

		[DataMember]
		public int TotalPointSum { get; set; }
	}
}
