using ExamPlatform.ViewModels.User.Response;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Test.Response
{
    [DataContract]
	public class VMTestResponse : BaseResponse
	{
		[DataMember]
		public VMTestDetails Test { get; set; }
	}
}
