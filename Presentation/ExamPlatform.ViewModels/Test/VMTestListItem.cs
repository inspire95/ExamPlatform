using ExamPlatform.ViewModels.CategoryType;
using ExamPlatform.ViewModels.Test.Response;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Test
{
    [DataContract]
	public class VMTestListItem
	{
		[DataMember]
		public int TestId { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public int TotalPointSum { get; set; }

		[DataMember]
		public ICollection<VMCategoryTypeItemList> TestCategories { get; set; }

        public static VMGetTestListResponse ToResponse(List<VMTestListItem> vmbsic)
        {
            var vmResponse = new VMGetTestListResponse
            {
                Tests = vmbsic
            };
            return vmResponse;
        }

        public static VMTestResponse ToResponse(VMTestDetails vmbsic)
        {
            var toResponse = new VMTestResponse
            {
                Test = vmbsic
            };
            return toResponse;
        }
    }
}
