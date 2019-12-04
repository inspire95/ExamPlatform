using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Question.Request
{
    [DataContract]
    public class VMCreateQuestionRequest
    {
        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public int PointsSum { get; set; }

        [DataMember]
        public int QuestionTypeId { get; set; }

        [DataMember]
        public ICollection<int> CategoryTypeIds { get; set; }
    }
}
