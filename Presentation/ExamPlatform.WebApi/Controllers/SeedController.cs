using ExamPlatform.Service.Interfaces;
using ExamPlatform.Service.Services;
using ExamPlatform.ViewModels;
using ExamPlatform.ViewModels.User.Response;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExamPlatform.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Seed")]
    public class SeedController : ControllerBase
    {
        private readonly ISeedService _seedService;

        public SeedController(SeedService seedService)
        {
            _seedService = seedService;
        }

        [Route("DoSeed")]
        [HttpGet]
        public BaseResponse<BooleanResponse> DoSeed()
        {
            try
            {
                bool result = _seedService.Seed();
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