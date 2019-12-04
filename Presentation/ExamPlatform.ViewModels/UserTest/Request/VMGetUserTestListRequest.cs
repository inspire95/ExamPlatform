using System;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.UserTest.Request
{
    [DataContract]
    public class VMGetUserTestListRequest
    {
		[DataMember]
		public Guid UserId { get; set; }
	}
}
