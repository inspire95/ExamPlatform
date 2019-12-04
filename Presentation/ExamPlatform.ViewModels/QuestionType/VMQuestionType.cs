using ExamPlatform.ViewModels.QuestionType.Response;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.QuestionType
{
    [DataContract]
    public class VMQuestionType
    {
        [DataMember]
        public int QuestionTypeId { get; set; }

        [DataMember]
        public string Name { get; set; }


        public static VMQuestionTypeResponse ToResponse(VMQuestionType vmModel)
        {
            var vmResponse = new VMQuestionTypeResponse
            {
                QuestionType = vmModel
            };

            return vmResponse;
        }

        public static VMQuestionTypeListResponse ToResponse(List<VMQuestionType> vmModel)
        {
            var vmResponse = new VMQuestionTypeListResponse
            {
                QuestionTypes = vmModel
            };

            return vmResponse;
        }
    }
}