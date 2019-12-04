using ExamPlatform.ViewModels.User.Response;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.UserTest.Response
{
    [DataContract]
    public class VMGetUserTestListResponse : BaseResponse
    {
        [DataMember]
        public ICollection<VMUserTestItemList> UserTests { get; set; }
    }
}
