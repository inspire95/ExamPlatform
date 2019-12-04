using ExamPlatform.Service.Interfaces;
using ExamPlatform.ViewModels;
using ExamPlatform.ViewModels.User.Response;
using ExamPlatform.ViewModels.UserTestAnswer;
using ExamPlatform.ViewModels.UserTestAnswer.Request;
using ExamPlatform.ViewModels.UserTestAnswer.Response;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExamPlatform.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/UserTestAnswers")]
    public class UserTestAnswersController : ControllerBase
    {
        private readonly IUserTestAnswerService _userTestAnswerService;

        public UserTestAnswersController(IUserTestAnswerService userTestAnswerService)
        {
            _userTestAnswerService = userTestAnswerService;
        }

        [Route("GetUserTestAnswersList")]
        [HttpGet]
        public BaseResponse<VMUserTestAnswerListResponse> GetAll(VMGetUserTestAnswerListRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMUserTestAnswerListResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _userTestAnswerService.GetAll(vmRequest);
                var responseObject = VMUserTestAnswer.ToResponse(result);
                var response = BaseResponse<VMUserTestAnswerListResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMUserTestAnswerListResponse>.SetError(exc);
            }
        }

		[Route("GetUserTestOpenAnswersList")]
		[HttpGet]
		public VMUserTestAnswerListResponse GetAllOpenAnswers(VMGetUserTestAnswerListRequest vmRequest)
		{
			if (vmRequest == null)
			{
				throw new Exception("Not Found");
			}

			var result = _userTestAnswerService.GetAllOpenAnswers(vmRequest);
			var response = VMUserTestAnswer.ToResponse(result);
			return response;
		}

		[Route("GetUserAnswersToQuestion")]
        [HttpGet]
        public BaseResponse<VMUserTestAnswerListResponse> GetAllToQuestion(VMGetUserAnswersToQuestionRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMUserTestAnswerListResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _userTestAnswerService.GetAllToQuestion(vmRequest);
                var responseObject = VMUserTestAnswer.ToResponse(result);
                var response = BaseResponse<VMUserTestAnswerListResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMUserTestAnswerListResponse>.SetError(exc);
            }
        }

        [Route("CreateUserTestAnswer")]
        [HttpPost]
        public BaseResponse<VMUserTestAnswerResponse> Create([FromBody] VMCreateUserTestAnswerRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMUserTestAnswerResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _userTestAnswerService.Create(vmRequest);
                var responseObject = VMUserTestAnswer.ToResponse(result);
                var response = BaseResponse<VMUserTestAnswerResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMUserTestAnswerResponse>.SetError(exc);
            }
        }

        [Route("DeleteUserAnswersByQustion")]
        [HttpDelete]
        public BaseResponse<BooleanResponse> Remove(VMRemoveUserTestAnswerRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<BooleanResponse>.SetError("Request body is empty");
            }

            try
            {
                bool result = _userTestAnswerService.RemoveUserAnswersByQuestion(vmRequest);
                BooleanResponse responseObject = new BooleanResponse(result);
                var response = BaseResponse<BooleanResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<BooleanResponse>.SetError(exc);
            }
        }

        [Route("VerifyOpenUserAnswer")]
        [HttpGet]
        public BaseResponse<VMUserTestAnswerResponse> VerifyOpenUserAnswer(VMVerifyOpenUserAnswerRequest vmRequest)
        {
            if (vmRequest == null)
            {
                return BaseResponse<VMUserTestAnswerResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _userTestAnswerService.VerifyOpenUserQuestion(vmRequest);
                var responseObject = VMUserTestAnswer.ToResponse(result);
                var response = BaseResponse<VMUserTestAnswerResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMUserTestAnswerResponse>.SetError(exc);
            }
        }
    }
}
