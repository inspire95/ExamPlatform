using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Test.Request
{
    [DataContract]
    public class VMUpdateTestRequest : VMCreateTestRequest
    {
        [DataMember]
        public int TestId { get; set; }

        [DataMember]
        public int TotalPointSum { get; set; }

        [DataMember]
        public ICollection<int> TestQuestionIds { get; set; }
    }
}
