using ExamPlatform.ViewModels.UserTest;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.User.Response
{
    [DataContract]
	public class VMUserResponse : BaseResponse
	{
		[DataMember]
		public VMUserDetails User { get; set; }
		[DataMember]
		public ICollection<VMUserTestItemList> UserTests { get; set; }
	}
}
