using ExamPlatform.ViewModels.User.Response;
using System.Collections.Generic;

namespace ExamPlatform.ViewModels.UserTestStatus.Response
{

    public class VMGetUserTestStatusListResponse : BaseResponse
    {
		public ICollection<VMUserTestStatus> UserTestStatuses { get; set; }
	}
}
