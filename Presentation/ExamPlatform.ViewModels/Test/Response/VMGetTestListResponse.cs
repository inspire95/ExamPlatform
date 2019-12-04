using ExamPlatform.ViewModels.User.Response;
using System.Collections.Generic;

namespace ExamPlatform.ViewModels.Test.Response
{
    public class VMGetTestListResponse : BaseResponse
	{
		public ICollection<VMTestListItem> Tests { get; set; }
	}
}
