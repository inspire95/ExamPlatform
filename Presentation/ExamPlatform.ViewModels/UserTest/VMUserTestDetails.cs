using ExamPlatform.ViewModels.UserTest;
using System;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.UserTestDetails
{
    [DataContract]
	public class VMUserTestDetails : VMUserTestItemList
	{
        [DataMember]
        public DateTime? EndDate { get; set; }

        [DataMember]
        public Guid UserId { get; set; }

		[DataMember]
		public int TotalPointSum { get; set; }
	}
}
