using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Test.Request
{
    [DataContract]
	public class VMRemoveTestRequest
	{
		[DataMember]
		public int TestId { get; set; }
	}
}
