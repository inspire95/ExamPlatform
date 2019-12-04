using ExamPlatform.Service.Interfaces;
using ExamPlatform.ViewModels.AttachmentType;
using ExamPlatform.ViewModels.AttachmentType.Request;
using ExamPlatform.ViewModels.AttachmentType.Response;
using ExamPlatform.ViewModels.User.Response;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExamPlatform.WebApi.Controllers
{
    [Produces("application/json")]
	[Route("api/AttachmentType")]
    public class AttachmentTypeController : ControllerBase
    {
		private readonly IAttachmentTypeService _attachmentTypeService;
		public AttachmentTypeController(IAttachmentTypeService attachmentTypeService)
		{
			_attachmentTypeService = attachmentTypeService;
		}

		[Route("GetAttachmentTypes")]
		[HttpGet]
		public BaseResponse<VMGetAttachmentTypeListResponse> GetAttachmentTypes(VMGetAttachmentTypeListRequest vmRequest)
		{
            if (vmRequest == null)
            {
                return BaseResponse<VMGetAttachmentTypeListResponse>.SetError("Request body is empty");
            }

            try
            {
                var result = _attachmentTypeService.GettAll(vmRequest);
                var responseObject = VMAttachmentTypeList.ToResponse(result);
                var response = BaseResponse<VMGetAttachmentTypeListResponse>.SetResponse(responseObject);
                return response;
            }
            catch (Exception exc)
            {
                return BaseResponse<VMGetAttachmentTypeListResponse>.SetError(exc);
            }
		}
    }
}