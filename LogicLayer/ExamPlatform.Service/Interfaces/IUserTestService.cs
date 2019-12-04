using System.Collections.Generic;
using ExamPlatform.ViewModels.UserTest;
using ExamPlatform.ViewModels.UserTest.Request;
using ExamPlatform.ViewModels.UserTestDetails;

namespace ExamPlatform.Service.Interfaces
{
	public interface IUserTestService
	{
		VMUserTestDetails Get(VMGetUserTestDetailsRequest request);
		VMUserTestDetails Create(VMCreateUserTestRequest request);
		bool Remove(VMRemoveUserTestRequest request);
		VMUserTestDetails Update(VMUpdateUserTestRequest request);
		List<VMUserTestItemList> GetAll(VMGetUserTestListRequest request);
		bool StartUserTest(VMStartUserTestRequest request);
        VMUserTestDetails FinishUserTest(VMFinishUserTestRequest request);
        VMUserTestDetails CheckSummaryUserTest(VMCheckSummaryUserTestRequest request);
    }
}
