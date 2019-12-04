using ExamPlatform.ViewModels.Role.Response;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Role
{
    [DataContract]
    public class VMRole
    {
        [DataMember]
        public string Name { get; set; }

        public static VMRoleListResponse ToResponse(List<VMRole> vmModel)
        {
            var vmResponse = new VMRoleListResponse
            {
                Roles = vmModel
            };

            return vmResponse;
        }

        public static VMRoleResponse ToResponse(VMRole vmModel)
        {
            var vmResponse = new VMRoleResponse
            {
                Role = vmModel
            };

            return vmResponse;
        }
    }    
}