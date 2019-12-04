
using System.Collections.Generic;
using ExamPlatform.ViewModels.Test;
using ExamPlatform.ViewModels.Test.Request;

namespace ExamPlatform.Service.Interfaces
{
	public interface ITestService
	{
		List<VMTestListItem> GetAll(VMGetTestsRequest vmRequest);
		VMTestDetails Get(VMGetTestDetailsRequest vmRequest);
		VMTestDetails Create(VMCreateTestRequest vmRequest);
		bool Remove(VMRemoveTestRequest vmRequest);
		VMTestDetails Update(VMUpdateTestRequest vmRequest);
        VMTestDetails Generate(VMGenerateTestRequest vmRequest);
    }
}
