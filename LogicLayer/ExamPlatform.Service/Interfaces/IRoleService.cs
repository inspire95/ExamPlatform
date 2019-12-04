using ExamPlatform.ViewModels.Role;
using ExamPlatform.ViewModels.Role.Request;
using System;
using System.Collections.Generic;

namespace ExamPlatform.Service.Services
{
    public interface IRoleService
    {
        List<VMRole> GetAll(VMGetRoleListRequest request);
        VMRole Get(VMGetRoleRequest request);
        bool AssignRoleToUser(Guid userId, ICollection<int> roleIdList);
    }
}