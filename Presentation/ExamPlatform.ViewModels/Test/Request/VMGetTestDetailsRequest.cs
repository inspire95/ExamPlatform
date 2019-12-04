using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Test.Request
{
    [DataContract]
	public class VMGetTestDetailsRequest
	{
		[DataMember]
		public int TestId { get; set; }
	}
}
