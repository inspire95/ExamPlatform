using ExamPlatform.ViewModels.QuestionType;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.TestsQuestions
{
    [DataContract]
	public class VMTestQuestions
	{
		[DataMember]
		public int QuestionId { get; set; }

		[DataMember]
		public  int TestId { get; set; }

		[DataMember]
		public ICollection<VMQuestionType> TestQuestions { get; set; }
	}
}
