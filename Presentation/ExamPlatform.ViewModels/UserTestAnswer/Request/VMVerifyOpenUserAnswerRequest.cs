using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.UserTestAnswer.Request
{
    [DataContract]
    public class VMVerifyOpenUserAnswerRequest
    {
        [DataMember]
        public int UserTestAnswerId { get; set; }
        [DataMember]
        public int PointsForOpenQuestion { get; set; }
    }
}
