using System;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.UserTest.Request
{
    [DataContract]
    public class VMCreateUserTestRequest
    {
        [DataMember]
        public int TestId { get; set; }

        [DataMember]
        public Guid UserId { get; set; }

		[DataMember]
		public int TestSummaryTypeId { get; set; }

		[DataMember]
		public int UserTestStatusId { get; set; }
	}
}
