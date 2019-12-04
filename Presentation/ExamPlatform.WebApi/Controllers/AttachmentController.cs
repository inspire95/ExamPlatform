using ExamPlatform.Service.Interfaces;
using ExamPlatform.ViewModels.Attachment;
using ExamPlatform.ViewModels.Attachment.Request;
using ExamPlatform.ViewModels.Attachment.Response;
using ExamPlatform.ViewModels.User.Response;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExamPlatform.WebApi.Controllers
{
    [Produces("application/json")]
	[Route("api/Attachment")]
    public class AttachmentController : ControllerBase
    {
		private readonly IAttachmentService _attachmentService;
		public AttachmentController(IAttachmentService attachmentService)
		{
			_attachmentService = attachmentService;
		}

		[Route("CreateAttachment")]
		[HttpPost]
		public BaseResponse<VMAttachmentResponse> Create([FromBody]VMCreateAttechmentRequest vmRequest)
		{
            if (vmRequest == null)
            {
                return BaseResponse<VMAttachmentResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _attachmentService.Create(vmRequest);
                var responseObject = VMAttachment.ToResponse(result);
                var response = BaseResponse<VMAttachmentResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMAttachmentResponse>.SetError(exc);
            }
		}
    }
}