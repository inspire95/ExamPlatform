using ExamPlatform.ViewModels.UserTestAnswer.Response;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.UserTestAnswer
{
    [DataContract]
    public class VMUserTestAnswer
    {
        [DataMember]
        public int UserTestAnswerId { get; set; }
        [DataMember]
        public string Content { get; set; }
        [DataMember]
        public int? AnswerId { get; set; }
		[DataMember]
		public string AnswerContent { get; set; }
		[DataMember]
		public string QuestionContent { get; set; }
		[DataMember]
		public int? AnswerPoint { get; set; }
		[DataMember]
        public int QuestionId { get; set; }
		[DataMember]
		public int? PointsForOpenQuestion { get; set; }

		public static VMUserTestAnswerListResponse ToResponse(List<VMUserTestAnswer> vmModel)
        {
            var vmResponse = new VMUserTestAnswerListResponse
            {
                UserTestAnswers = vmModel
            };

            return vmResponse;
        }

        public static VMUserTestAnswerResponse ToResponse(VMUserTestAnswer vmModel)
        {
            var vmResponse = new VMUserTestAnswerResponse
            {
                UserTestAnswer = vmModel
            };

            return vmResponse;
        }
    }
}
