using ExamPlatform.ViewModels.User.Response;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Question.Response
{
    [DataContract]
    public class VMGetQuestionDetailsResponse : BaseResponse
    {
        [DataMember]
        public VMQuestion Question { get; set; }
    }
}
