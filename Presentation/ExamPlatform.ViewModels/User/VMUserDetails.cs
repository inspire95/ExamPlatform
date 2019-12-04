using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.User
{
    [DataContract]
    public class VMUserDetails : VMUserListItem
    {
		[DataMember]
		public ICollection<int> UserRoleIds { get; set; }
	}
}
