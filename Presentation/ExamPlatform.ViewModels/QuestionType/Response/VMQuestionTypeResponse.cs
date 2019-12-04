using ExamPlatform.ViewModels.User.Response;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.QuestionType.Response
{
    [DataContract]
    public class VMQuestionTypeResponse : BaseResponse
    {
        [DataMember]
        public VMQuestionType QuestionType { get; set; }
    }
}