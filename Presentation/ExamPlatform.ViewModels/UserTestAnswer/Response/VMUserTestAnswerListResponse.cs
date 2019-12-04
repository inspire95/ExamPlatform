using ExamPlatform.ViewModels.User.Response;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.UserTestAnswer.Response
{
    [DataContract]
    public class VMUserTestAnswerListResponse : BaseResponse
    {
        [DataMember]
        public ICollection<VMUserTestAnswer> UserTestAnswers { get; set; }
    }
}