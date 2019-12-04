using ExamPlatform.Service.Interfaces;
using ExamPlatform.ViewModels;
using ExamPlatform.ViewModels.Answer;
using ExamPlatform.ViewModels.Answer.Request;
using ExamPlatform.ViewModels.Answer.Response;
using ExamPlatform.ViewModels.User.Response;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExamPlatform.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Answers")]
    public class AnswersController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        public AnswersController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [Route("GetAnswers")]
        [HttpGet]
        public BaseResponse<VMGetAnswerListResponse> GetAnswers(VMGetAnswerListRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMGetAnswerListResponse>.SetError("Request body is empty");
            }
            try
            {
                var result = _answerService.GetAll(vmRequest);
                var responseObject = VMAnswerListItem.ToResponse(result);
                var response = BaseResponse<VMGetAnswerListResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMGetAnswerListResponse>.SetError(exc);
            }
        }

        [Route("GetAnswerDetails")]
        [HttpGet]
        public BaseResponse<VMGetAnswerResponse> Get(VMGetAnswerDetailsRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMGetAnswerResponse>.SetError("Request body is empty");
            }
            try
            {
                var result = _answerService.Get(vmRequest);
                var responseObject = VMAnswerListItem.ToResponse(result);
                var response = BaseResponse<VMGetAnswerResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMGetAnswerResponse>.SetError(exc);
            }
        }

        [Route("CreateAnswer")]
        [HttpPost]
        public BaseResponse<VMGetAnswerResponse> Create([FromBody]VMCreateAnswerRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMGetAnswerResponse>.SetError("Request body is empty");
            }
            try
            {
                var result = _answerService.Create(vmRequest);
                var responseObject = VMAnswerListItem.ToResponse(result);
                var response = BaseResponse<VMGetAnswerResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMGetAnswerResponse>.SetError(exc);
            }
        }

        [Route("UpdateAnswer")]
        [HttpPut]
        public BaseResponse<VMGetAnswerResponse> Update([FromBody]VMUpdateAnswerRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMGetAnswerResponse>.SetError("Request body is empty");
            }
            try
            {
                var result = _answerService.Update(vmRequest);
                var responseObject = VMAnswerListItem.ToResponse(result);
                var response = BaseResponse<VMGetAnswerResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMGetAnswerResponse>.SetError(exc);
            }
        }

        [Route("DeleteAnswer")]
        [HttpDelete]
        public BaseResponse<BooleanResponse> Remove(VMRemoveAnswerRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<BooleanResponse>.SetError("Request body is empty");
            }
            try
            {
                bool result = _answerService.Remove(vmRequest);
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