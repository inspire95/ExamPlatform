using ExamPlatform.ViewModels.UserTestAnswer;
using ExamPlatform.ViewModels.UserTestAnswer.Request;
using System.Collections.Generic;

namespace ExamPlatform.Service.Interfaces
{
    public interface IUserTestAnswerService
    {
        List<VMUserTestAnswer> GetAll(VMGetUserTestAnswerListRequest request);
        List<VMUserTestAnswer> GetAllToQuestion(VMGetUserAnswersToQuestionRequest request);
        VMUserTestAnswer Create(VMCreateUserTestAnswerRequest vmrequest);
        bool RemoveUserAnswersByQuestion(VMRemoveUserTestAnswerRequest vmrequest);
        VMUserTestAnswer VerifyOpenUserQuestion(VMVerifyOpenUserAnswerRequest vmrequest);
        List<VMUserTestAnswer> GetAllOpenAnswers(VMGetUserTestAnswerListRequest request);
    }
}