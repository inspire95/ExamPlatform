using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Test
{
    [DataContract]
	public class VMTestDetails : VMTestListItem
	{

		[DataMember]
		public string Content { get; set; }

		[DataMember]
		public int Time { get; set; }

        [DataMember]
		public int RequiredPercentage { get; set; }
                
        [DataMember]
        public ICollection<int> TestQuestionIds { get; set; }
	}
}
