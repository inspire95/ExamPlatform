using ExamPlatform.Service.Services;
using ExamPlatform.ViewModels.Role;
using ExamPlatform.ViewModels.Role.Request;
using ExamPlatform.ViewModels.Role.Response;
using ExamPlatform.ViewModels.User.Response;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExamPlatform.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Roles")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [Route("GetRoles")]
        [HttpGet]
        public BaseResponse<VMRoleListResponse> GetRoles(VMGetRoleListRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMRoleListResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _roleService.GetAll(vmRequest);
                var responseObject = VMRole.ToResponse(result);
                var response = BaseResponse<VMRoleListResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMRoleListResponse>.SetError(exc);
            }
        }

        [Route("GetRole")]
        [HttpGet]
        public BaseResponse<VMRoleResponse> Get(VMGetRoleRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMRoleResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _roleService.Get(vmRequest);
                var responseObject = VMRole.ToResponse(result);
                var response = BaseResponse<VMRoleResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMRoleResponse>.SetError(exc);
            }
        }
    }
}