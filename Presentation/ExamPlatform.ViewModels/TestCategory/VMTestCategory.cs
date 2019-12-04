using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.TestCategory
{
    [DataContract]
	public class VMTestCategory
	{
		[DataMember]
		public int CategoryTypeId { get; set; }
		[DataMember]
		public int TestId { get; set; }
	}
}
