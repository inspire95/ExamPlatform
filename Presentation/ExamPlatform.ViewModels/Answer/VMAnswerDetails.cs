using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Answer
{
    [DataContract]
    public class VMAnswerDetails : VMAnswerListItem
    {
        [DataMember]
        public int QuestionId { get; set; }
    }
}
