using ExamPlatform.ViewModels.Question.Response;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Question
{
    [DataContract]
    public class VMQuestion
    {
        [DataMember]
        public int QuestionId { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public int PointsSum { get; set; }

        [DataMember]
        public int QuestionTypeId { get; set; }

        [DataMember]
        public ICollection<int> CategoryTypeIds { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        public static VMGetQuestionDetailsResponse ToResponse(VMQuestion vmModel)
        {
            var vmResponse = new VMGetQuestionDetailsResponse
            {
                Question = vmModel
            };

            return vmResponse;
        }

        public static VMGetQuestionListResponse ToResponse(List<VMQuestion> vmModel)
        {
            var vmResponse = new VMGetQuestionListResponse
            {
                Questions = vmModel
            };

            return vmResponse;
        }        
    }
}
