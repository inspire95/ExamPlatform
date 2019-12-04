using System.Runtime.Serialization;
using ExamPlatform.ViewModels.User.Response;

namespace ExamPlatform.ViewModels.UserTest.Response
{
    [DataContract]
    public class VMGetUserTestDetailsResponse : BaseResponse
    {
        [DataMember]
        public VMUserTestItemList UserTest { get; set; }
    }
}
