using ExamPlatform.ViewModels.User.Response;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.AttachmentType.Response
{
    [DataContract]
	public class VMGetAttachmentTypeListResponse : BaseResponse
    {
		[DataMember]
		public ICollection<VMAttachmentTypeList> AttachmentTypes { get; set; }
	}
}
