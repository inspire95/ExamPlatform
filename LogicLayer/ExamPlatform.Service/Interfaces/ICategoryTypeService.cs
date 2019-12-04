using System;
using System.Collections.Generic;
using System.Text;
using ExamPlatform.ViewModels.CategoryType;
using ExamPlatform.ViewModels.CategoryType.Request;

namespace ExamPlatform.Service.Interfaces
{
	public interface ICategoryTypeService
	{
		List<VMCategoryTypeItemList> GetAll(VMGetCategoryTypeListRequest vmrequest);
		VMCategoryTypeDetails Get(VMGetCategoryTypeDetailsRequest vmrequest);
		VMCategoryTypeDetails Create(VMCreateCategoryTypeRequest vmrequest);
		bool Remove(VMRemoveCategoryTypeRequest vmrequest);
		VMCategoryTypeDetails Update(VMUpdateCategoryTypeRequest vmrequest);
	}
}
