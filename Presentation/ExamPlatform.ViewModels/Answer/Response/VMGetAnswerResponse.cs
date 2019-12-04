using ExamPlatform.ViewModels.User.Response;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Answer.Response
{
    [DataContract]
    public class VMGetAnswerResponse : BaseResponse
    {
        [DataMember]
        public VMAnswerDetails Answer { get; set; }
    }
}
