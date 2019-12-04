using ExamPlatform.ViewModels.User.Response;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Question.Response
{
    [DataContract]
    public class VMGetQuestionListResponse : BaseResponse
    {
        [DataMember]
        public ICollection<VMQuestion> Questions { get; set; }
    }
}
