using ExamPlatform.ViewModels.Attachment.Response;
using System.Runtime.Serialization;

namespace ExamPlatform.ViewModels.Attachment
{
    [DataContract]
    public class VMAttachment
    {
        [DataMember]
        public int AttachmentId { get; set; }

        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public string FilePath { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public string AttachmentTypeName { get; set; }

        [DataMember]
        public int QuestionId { get; set; }

        public static VMAttachmentResponse ToResponse(VMAttachment vmModel)
        {
            var vmResponse = new VMAttachmentResponse {
                Attachment = vmModel
            };

            return vmResponse;
        }
    }
}
