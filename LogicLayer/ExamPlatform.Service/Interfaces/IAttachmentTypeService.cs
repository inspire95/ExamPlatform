using System;
using System.Collections.Generic;
using System.Text;
using ExamPlatform.ViewModels.AttachmentType;
using ExamPlatform.ViewModels.AttachmentType.Request;

namespace ExamPlatform.Service.Interfaces
{
	public interface IAttachmentTypeService
	{
		List<VMAttachmentTypeList> GettAll(VMGetAttachmentTypeListRequest request);
	}
}
