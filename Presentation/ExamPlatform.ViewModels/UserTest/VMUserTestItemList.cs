using ExamPlatform.ViewModels.CategoryType;
using ExamPlatform.ViewModels.UserTest.Response;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.UserTest
{
    [DataContract]
    public class VMUserTestItemList
    {
        [DataMember]
        public Guid UserTestId { get; set; }

		[DataMember]
		public string TestName { get; set; }

		[DataMember]
        public int TestId { get; set; }
        
		[DataMember]
		public string TestSummaryTypeName { get; set; }

		[DataMember]
		public string UserTestStatusName { get; set; }

		[DataMember]
		public int TotalPointAquired { get; set; }

		[DataMember]
		public DateTime? StartDate { get; set; }

		[DataMember]
		public ICollection<VMCategoryTypeItemList> TestsCategories { get; set; }

		public static VMGetUserTestListResponse ToResponse(List<VMUserTestItemList> vmbsic)
        {
            var vmResponse = new VMGetUserTestListResponse
            {
                UserTests = vmbsic
            };
            return vmResponse;
        }

        public static VMGetUserTestDetailsResponse ToResponse(VMUserTestItemList vmbsic)
        {
            var toResponse = new VMGetUserTestDetailsResponse
            {
                UserTest = vmbsic
            };
            return toResponse;
        }
    }
}

