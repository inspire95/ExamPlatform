using ExamPlatform.ViewModels.User.Response;
using System.Collections.Generic;

namespace ExamPlatform.ViewModels.TestSummaryType.Response
{
    public class VMGetTestSummaryTypeListResponse : BaseResponse
    {
		public ICollection<VMTestSummaryType> TestSummaryTypes { get; set; }
	}
}
