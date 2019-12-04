using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Attachment.Request
{
    [DataContract]
    public class VMRemoveAttachmentRequest
    {
        [DataMember]
        public int AttachmentId { get; set; }
    }
}
