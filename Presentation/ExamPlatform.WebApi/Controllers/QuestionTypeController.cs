using ExamPlatform.Service.Interfaces;
using ExamPlatform.Service.Services;
using ExamPlatform.ViewModels.QuestionType;
using ExamPlatform.ViewModels.QuestionType.Request;
using ExamPlatform.ViewModels.QuestionType.Response;
using ExamPlatform.ViewModels.User.Response;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExamPlatform.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/QuestionType")]
    public class QuestionTypeController : ControllerBase
    {
        private readonly IQuestionTypeService _service;

        public QuestionTypeController(QuestionTypeService service)
        {
            _service = service;
        }

        [Route("GetQuestionTypesList")]
        [HttpGet]
        public BaseResponse<VMQuestionTypeListResponse> GetAll(VMGetQuestionTypeListRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMQuestionTypeListResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _service.GetAll(vmRequest);
                var responseObject = VMQuestionType.ToResponse(result);
                var response = BaseResponse<VMQuestionTypeListResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMQuestionTypeListResponse>.SetError(exc);
            }
        }

        [Route("GetQuestionType")]
        [HttpGet]
        public BaseResponse<VMQuestionTypeResponse> Get(VMGetQuestionTypeRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMQuestionTypeResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _service.Get(vmRequest);
                var responseObject = VMQuestionType.ToResponse(result);
                var response = BaseResponse<VMQuestionTypeResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMQuestionTypeResponse>.SetError(exc);
            }
        }
    }
}