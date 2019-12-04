using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Attachment.Request
{
    [DataContract]
    public class VMUpdateAttachmentRequest : VMCreateAttechmentRequest
    {
        [DataMember]
        public int AttachmentId { get; set; }
    }
}
