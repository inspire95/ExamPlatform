using ExamPlatform.Service.Interfaces;
using ExamPlatform.ViewModels;
using ExamPlatform.ViewModels.Test;
using ExamPlatform.ViewModels.Test.Request;
using ExamPlatform.ViewModels.Test.Response;
using ExamPlatform.ViewModels.User.Response;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExamPlatform.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Tests")]
    public class TestsController : ControllerBase
    {
        private readonly ITestService _testService;
        public TestsController(ITestService testService)
        {
            _testService = testService;
        }
        [Route("GetTests")]
        [HttpGet]
        public BaseResponse<VMGetTestListResponse> GetTests(VMGetTestsRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMGetTestListResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _testService.GetAll(vmRequest);
                var responseObject = VMTestListItem.ToResponse(result);
                var response = BaseResponse<VMGetTestListResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMGetTestListResponse>.SetError(exc);
            }
        }

        [Route("GetTestDetails")]
        [HttpGet]
        public BaseResponse<VMTestResponse> Get(VMGetTestDetailsRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMTestResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _testService.Get(vmRequest);
                var responseObject = VMTestListItem.ToResponse(result);
                var response = BaseResponse<VMTestResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMTestResponse>.SetError(exc);
            }
        }

        [Route("CreateTest")]
        [HttpPost]
        public BaseResponse<VMTestResponse> Create([FromBody]VMCreateTestRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMTestResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _testService.Create(vmRequest);
                var responseObject = VMTestListItem.ToResponse(result);
                var response = BaseResponse<VMTestResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMTestResponse>.SetError(exc);
            }
        }

        [Route("DeleteTest")]
        [HttpDelete]
        public BaseResponse<BooleanResponse> Remove(VMRemoveTestRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<BooleanResponse>.SetError("Request body is empty");
            }
            try
            {
                bool result = _testService.Remove(vmRequest);
                BooleanResponse responseObject = new BooleanResponse(result);
                var response = BaseResponse<BooleanResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<BooleanResponse>.SetError(exc);
            }
        }

        [Route("UpdateTest")]
        [HttpPut]
        public BaseResponse<VMTestResponse> Update([FromBody]VMUpdateTestRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMTestResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _testService.Update(vmRequest);
                var responseObject = VMTestListItem.ToResponse(result);
                var response = BaseResponse<VMTestResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMTestResponse>.SetError(exc);
            }
        }

        [Route("GenerateTest")]
        [HttpPost]
        public BaseResponse<VMTestResponse> Generate([FromBody]VMGenerateTestRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMTestResponse>.SetError("Request body is empty");
            }


            var result = _testService.Generate(vmRequest);
            var responseObject = VMTestListItem.ToResponse(result);
            var response = BaseResponse<VMTestResponse>.SetResponse(responseObject);
            return response;

        }
    }
} 