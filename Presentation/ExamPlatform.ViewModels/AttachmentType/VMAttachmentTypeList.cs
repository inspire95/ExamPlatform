using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using ExamPlatform.ViewModels.AttachmentType.Response;

namespace ExamPlatform.ViewModels.AttachmentType
{
	[DataContract]
	public class VMAttachmentTypeList
	{
		[DataMember]
		public int AttachmentTypeId { get; set; }

		[DataMember]
		public string Name { get; set; }

		public static VMGetAttachmentTypeListResponse ToResponse(List<VMAttachmentTypeList> vmbsic)
		{
			var vmResponse = new VMGetAttachmentTypeListResponse
			{
				AttachmentTypes = vmbsic
			};
			return vmResponse;
		}
	}

}