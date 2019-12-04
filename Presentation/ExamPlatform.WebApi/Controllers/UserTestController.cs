using ExamPlatform.Service.Interfaces;
using ExamPlatform.ViewModels;
using ExamPlatform.ViewModels.User.Response;
using ExamPlatform.ViewModels.UserTest;
using ExamPlatform.ViewModels.UserTest.Request;
using ExamPlatform.ViewModels.UserTest.Response;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExamPlatform.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/UserTests")]
    public class UserTestController : ControllerBase
    {
        private readonly IUserTestService _userTestService;
        public UserTestController(IUserTestService userTestService)
        {
            _userTestService = userTestService;
        }

        [Route("GetUserTests")]
        [HttpGet]
        public BaseResponse<VMGetUserTestListResponse> GetUserTests(VMGetUserTestListRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMGetUserTestListResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _userTestService.GetAll(vmRequest);
                var responseObject = VMUserTestItemList.ToResponse(result);
                var response = BaseResponse<VMGetUserTestListResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMGetUserTestListResponse>.SetError(exc);
            }
        }
        [Route("GetUserTest")]
        [HttpGet]
        public BaseResponse<VMGetUserTestDetailsResponse> Get(VMGetUserTestDetailsRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMGetUserTestDetailsResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _userTestService.Get(vmRequest);
                var responseObject = VMUserTestItemList.ToResponse(result);
                var response = BaseResponse<VMGetUserTestDetailsResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMGetUserTestDetailsResponse>.SetError(exc);
            }
        }

        [Route("CreateUserTest")]
        [HttpPost]
        public BaseResponse<VMGetUserTestDetailsResponse> Create([FromBody] VMCreateUserTestRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMGetUserTestDetailsResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _userTestService.Create(vmRequest);
                var responseObject = VMUserTestItemList.ToResponse(result);
                var response = BaseResponse<VMGetUserTestDetailsResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMGetUserTestDetailsResponse>.SetError(exc);
            }
        }

        [Route("StartUserTest")]
        [HttpPost]
        public BaseResponse<BooleanResponse> StartUserTest([FromBody] VMStartUserTestRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<BooleanResponse>.SetError("Request body is empty");
            }

            try
            {
                bool result = _userTestService.StartUserTest(vmRequest);
                BooleanResponse responseObject = new BooleanResponse(result);
                var response = BaseResponse<BooleanResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<BooleanResponse>.SetError(exc);
            }
        }

        [Route("FinishUserTest")]
        [HttpPost]
        public BaseResponse<VMGetUserTestDetailsResponse> FinishUserTest([FromBody] VMFinishUserTestRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMGetUserTestDetailsResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _userTestService.FinishUserTest(vmRequest);
                var responseObject = VMUserTestItemList.ToResponse(result);
                var response = BaseResponse<VMGetUserTestDetailsResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMGetUserTestDetailsResponse>.SetError(exc);
            }
        }

        [Route("CheckSummary")]
        [HttpGet]
        public BaseResponse<VMGetUserTestDetailsResponse> CheckSummaryUserTest(VMCheckSummaryUserTestRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMGetUserTestDetailsResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _userTestService.CheckSummaryUserTest(vmRequest);
                var responseObject = VMUserTestItemList.ToResponse(result);
                var response = BaseResponse<VMGetUserTestDetailsResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMGetUserTestDetailsResponse>.SetError(exc);
            }
        }
    }
}