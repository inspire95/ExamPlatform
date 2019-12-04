using ExamPlatform.ViewModels.User.Response;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.TestSummaryType.Response
{
    [DataContract]
	public class VMGetTestSummaryTypeDetailsResponse : BaseResponse
    {
		[DataMember]
		public VMTestSummaryType TestSummaryType { get; set; }
	}
}
