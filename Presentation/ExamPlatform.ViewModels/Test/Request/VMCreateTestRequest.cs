using ExamPlatform.ViewModels.CategoryType;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Test.Request
{
    [DataContract]
	public class VMCreateTestRequest
	{
		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public string Content { get; set; }

		[DataMember]
		public int Time { get; set; }

        [DataMember]
        public int RequiredPercentage { get; set; }

        [DataMember]
		public ICollection<VMCategoryTypeItemList> TestCategories { get; set; }

	}
}
