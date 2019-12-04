using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ExamPlatform.ViewModels.Answer.Request
{
    [DataContract]
    public class VMRemoveAnswerRequest
    {
        [DataMember]
        public int AnswerId { get; set; }
    }
}
