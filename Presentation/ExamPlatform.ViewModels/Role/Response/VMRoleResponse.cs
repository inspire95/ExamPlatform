using ExamPlatform.ViewModels.User.Response;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Role.Response
{
    [DataContract]
    public class VMRoleResponse : BaseResponse
    {
        [DataMember]
        public VMRole Role { get; set; }
    }
}
