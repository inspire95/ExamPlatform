using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Role.Request
{
    [DataContract]
    public class VMGetRoleRequest
    {
        [DataMember]
        public int RoleId { get; set; }
    }
}