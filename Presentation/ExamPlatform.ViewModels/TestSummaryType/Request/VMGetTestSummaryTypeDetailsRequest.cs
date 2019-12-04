using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ExamPlatform.ViewModels.TestSummaryType.Request
{
	[DataContract]
	public class VMGetTestSummaryTypeDetailsRequest
	{
		[DataMember]
		public int TestSummaryTypeId { get; set; }
	}
}
