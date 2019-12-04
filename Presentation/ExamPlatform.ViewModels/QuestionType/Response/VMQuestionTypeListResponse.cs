using ExamPlatform.ViewModels.User.Response;
using System.Collections.Generic;

namespace ExamPlatform.ViewModels.QuestionType.Response
{
    public class VMQuestionTypeListResponse : BaseResponse
    {
        public ICollection<VMQuestionType> QuestionTypes { get; set; }
    }
}