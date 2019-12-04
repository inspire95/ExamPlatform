using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using ExamPlatform.ViewModels.TestSummaryType.Response;

namespace ExamPlatform.ViewModels.TestSummaryType
{
	[DataContract]
    public class VMTestSummaryType
    {
		[DataMember]
		public int TestSummaryTypeId { get; set; }

		[DataMember]
		public string Name { get; set; }

		public static VMGetTestSummaryTypeListResponse ToResponse(List<VMTestSummaryType> vmbsic)
		{
			var toResponse = new VMGetTestSummaryTypeListResponse
			{
				//TestSummaryTypes = vmbsic
				TestSummaryTypes = vmbsic
			};
			return toResponse;
		}

		//ToResponse(Create/Update/GetDetails)
		public static VMGetTestSummaryTypeDetailsResponse ToResponse(VMTestSummaryType vmbsic)
		{
			var toResponse = new VMGetTestSummaryTypeDetailsResponse
			{
				TestSummaryType = vmbsic
			};
			return toResponse;
		}

	}
}
