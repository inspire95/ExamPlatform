using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Attachment.Request
{
    [DataContract]
    public class VMGetAttachmentDetailsRequest
    {   
        [DataMember]
        public int AttachmentId { get; set; }
    }
}
