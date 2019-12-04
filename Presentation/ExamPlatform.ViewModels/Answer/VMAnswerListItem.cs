using ExamPlatform.ViewModels.Answer.Response;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Answer
{
    [DataContract]
    public class VMAnswerListItem
    {
        [DataMember]
        public int AnswerId { get; set; }
        [DataMember]
        public string Content { get; set; }
        [DataMember]
        public int Points { get; set; }
        [DataMember]
        public bool IsCorrect { get; set; }

        public static VMGetAnswerListResponse ToResponse(List<VMAnswerListItem> vmbsic)
        {
            var vmResponse = new VMGetAnswerListResponse
            {
                Answers = vmbsic
            };
            return vmResponse;
        }

        public static VMGetAnswerResponse ToResponse(VMAnswerDetails vmbsic)
        {
            var vmResponse = new VMGetAnswerResponse
            {
                Answer = vmbsic
            };
            return vmResponse;
        }
    }
}
