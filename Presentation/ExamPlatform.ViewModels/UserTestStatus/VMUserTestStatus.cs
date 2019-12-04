using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using ExamPlatform.ViewModels.UserTestStatus.Response;

namespace ExamPlatform.ViewModels.UserTestStatus
{
	[DataContract]
	public class VMUserTestStatus
	{
		[DataMember]
		public int UserTestStatusId { get; set; }

		[DataMember]
		public string Name { get; set; }

		public static VMGetUserTestStatusListResponse ToResponse(List<VMUserTestStatus> vmbsic)
		{
			var toResponse = new VMGetUserTestStatusListResponse
			{
				UserTestStatuses = vmbsic
			};
			return toResponse;
		}
	}
}
