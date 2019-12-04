using ExamPlatform.ViewModels.QuestionType;
using ExamPlatform.ViewModels.QuestionType.Request;
using System.Collections.Generic;

namespace ExamPlatform.Service.Interfaces
{
    public interface IQuestionTypeService
    {
        List<VMQuestionType> GetAll(VMGetQuestionTypeListRequest vmrequest);
        VMQuestionType Get(VMGetQuestionTypeRequest vmrequest);
    }
}