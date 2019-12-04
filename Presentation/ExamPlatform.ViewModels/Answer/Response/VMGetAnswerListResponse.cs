using ExamPlatform.ViewModels.User.Response;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Answer.Response
{
    [DataContract]
    public class VMGetAnswerListResponse : BaseResponse
    {
        [DataMember]
        public ICollection<VMAnswerListItem> Answers { get; set; }
    }
}
