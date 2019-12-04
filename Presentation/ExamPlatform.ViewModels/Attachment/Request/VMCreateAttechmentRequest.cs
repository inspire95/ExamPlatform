using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Attachment.Request
{
    [DataContract]
    public class VMCreateAttechmentRequest
    {
        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public string FilePath { get; set; }

        [DataMember]
        public int AttachmentTypeId { get; set; }

        [DataMember]
        public int QuestionId { get; set; }
    }
}
