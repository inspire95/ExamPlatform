using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.QuestionType.Request
{
    [DataContract]
    public class VMCreateQuestionTypeRequest
    {
        [DataMember]
        public string Name { get; set; }
    }
}