using ExamPlatform.Database;
using ExamPlatform.Service.Interfaces;
using ExamPlatform.ViewModels.AttachmentType;
using ExamPlatform.ViewModels.AttachmentType.Request;
using System.Collections.Generic;
using System.Linq;

namespace ExamPlatform.Service.Services
{
    public class AttachmentTypeService : IAttachmentTypeService
	{
		private readonly ExamPlatformContext _context;
		public AttachmentTypeService(ExamPlatformContext context)
		{
			_context = context;
		}

		public List<VMAttachmentTypeList> GettAll(VMGetAttachmentTypeListRequest request)
		{
			var attachmentTypes = _context.AttachementTypes
				.Select(x => new VMAttachmentTypeList
				{
					AttachmentTypeId = x.AttachmentTypeId,
					Name = x.Name
				}).ToList();
			return attachmentTypes;
		}
	}
}
