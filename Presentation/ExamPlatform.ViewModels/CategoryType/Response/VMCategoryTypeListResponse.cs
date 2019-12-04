using ExamPlatform.ViewModels.User.Response;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.CategoryType.Response
{
	[DataContract]
    public class VMGetCategoryTypeListResponse : BaseResponse
    {
		[DataMember]
        public ICollection<VMCategoryTypeItemList> CategoryTypes { get; set; }
    }
}
