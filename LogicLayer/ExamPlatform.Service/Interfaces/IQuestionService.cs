using ExamPlatform.ViewModels.Question;
using ExamPlatform.ViewModels.Question.Request;
using System.Collections.Generic;

namespace ExamPlatform.Service.Interfaces
{
    public interface IQuestionService
    {
        List<VMQuestion> GetAll(VMGetQuestionListRequest request);
        VMQuestion Get(VMGetQuestionDetailsRequest request);
        VMQuestion Create(VMCreateQuestionRequest request);
        bool Remove(VMRemoveQuestionRequest request);
        VMQuestion Update(VMUpdateQuestionRequest request);
    }
}
