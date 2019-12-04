using ExamPlatform.ViewModels.User.Response;
using System.Runtime.Serialization;
namespace ExamPlatform.ViewModels.Attachment.Response
{
    [DataContract]
    public class VMAttachmentResponse : BaseResponse
    {
        [DataMember]
        public VMAttachment Attachment { get; set; }
    }
}

