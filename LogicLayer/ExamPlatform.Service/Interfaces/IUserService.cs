using ExamPlatform.ViewModels.User;
using ExamPlatform.ViewModels.User.Request;
using System.Collections.Generic;

namespace ExamPlatform.Service.Interfaces
{
    public interface IUserService
	{
		List<VMUserListItem> GetAll(VMGetUserListRequest vmrequest);
		VMUserDetails Get(VMGetUserDetailsRequest vmrequest);
		VMUserDetails Create(VMCreateUserRequest vmrequest);
		bool Remove(VMRemoveUserRequest vmrequest);
		VMUserDetails Update(VMUpdateUserRequest vmrequest);
	}
}
