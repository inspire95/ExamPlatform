using ExamPlatform.ViewModels.User.Response;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.UserTestAnswer.Response
{
    [DataContract]
    public class VMUserTestAnswerResponse : BaseResponse
    {
        [DataMember]
        public VMUserTestAnswer UserTestAnswer { get; set; }
    }
}
