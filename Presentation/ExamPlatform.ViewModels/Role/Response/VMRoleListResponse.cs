using ExamPlatform.ViewModels.User.Response;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Role.Response
{
    [DataContract]
    public class VMRoleListResponse : BaseResponse
    {
        [DataMember]
        public ICollection<VMRole> Roles { get; set; }
    }
}
