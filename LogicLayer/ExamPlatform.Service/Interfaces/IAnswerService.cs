using System.Collections.Generic;
using ExamPlatform.ViewModels.Answer;
using ExamPlatform.ViewModels.Answer.Request;

namespace ExamPlatform.Service.Interfaces
{
	public interface IAnswerService
	{
		List<VMAnswerListItem> GetAll(VMGetAnswerListRequest vmrequest);
		VMAnswerDetails Get(VMGetAnswerDetailsRequest vmrequest);
        VMAnswerDetails Create(VMCreateAnswerRequest vmrequest);
		bool Remove(VMRemoveAnswerRequest vmrequest);
        VMAnswerDetails Update(VMUpdateAnswerRequest vmrequest);
	}
}
