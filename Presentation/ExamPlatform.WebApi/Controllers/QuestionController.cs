using ExamPlatform.Service.Interfaces;
using ExamPlatform.Service.Services;
using ExamPlatform.ViewModels;
using ExamPlatform.ViewModels.Question;
using ExamPlatform.ViewModels.Question.Request;
using ExamPlatform.ViewModels.Question.Response;
using ExamPlatform.ViewModels.User.Response;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExamPlatform.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Questions")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(QuestionService questionService)
        {
            _questionService = questionService;
        }


        [Route("GetQuestions")]
        [HttpGet]
        public BaseResponse<VMGetQuestionListResponse> GetAll(VMGetQuestionListRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMGetQuestionListResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _questionService.GetAll(vmRequest);
                var responseObject = VMQuestion.ToResponse(result);
                var response = BaseResponse<VMGetQuestionListResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMGetQuestionListResponse>.SetError(exc);
            }
        }

        [Route("GetQuestionDetails")]
        [HttpGet]
        public BaseResponse<VMGetQuestionDetailsResponse> Get(VMGetQuestionDetailsRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMGetQuestionDetailsResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _questionService.Get(vmRequest);
                var responseObject = VMQuestion.ToResponse(result);
                var response = BaseResponse<VMGetQuestionDetailsResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMGetQuestionDetailsResponse>.SetError(exc);
            }
        }

        [Route("CreateQuestion")]
        [HttpPost]
        public BaseResponse<VMGetQuestionDetailsResponse> Create([FromBody]VMCreateQuestionRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMGetQuestionDetailsResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _questionService.Create(vmRequest);
                var responseObject = VMQuestion.ToResponse(result);
                var response = BaseResponse<VMGetQuestionDetailsResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMGetQuestionDetailsResponse>.SetError(exc);
            }
        }

        [Route("UpdateQuestion")]
        [HttpPut]
        public BaseResponse<VMGetQuestionDetailsResponse> Update([FromBody]VMUpdateQuestionRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMGetQuestionDetailsResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _questionService.Update(vmRequest);
                var responseObject = VMQuestion.ToResponse(result);
                var response = BaseResponse<VMGetQuestionDetailsResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMGetQuestionDetailsResponse>.SetError(exc);
            }
        }

        [Route("DeleteQuestion")]
        [HttpDelete]
        public BaseResponse<BooleanResponse> Remove(VMRemoveQuestionRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<BooleanResponse>.SetError("Request body is empty");
            }
            try
            {
                bool result = _questionService.Remove(vmRequest);
                BooleanResponse responseObject = new BooleanResponse(result);
                var response = BaseResponse<BooleanResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<BooleanResponse>.SetError(exc);
            }
        }
    }
}
