
using ExamPlatform.ViewModels.Attachment;
using ExamPlatform.ViewModels.Attachment.Request;

namespace ExamPlatform.Service.Interfaces
{
    public interface IAttachmentService
    {
        VMAttachment Get(VMGetAttachmentDetailsRequest request);
        VMAttachment Create(VMCreateAttechmentRequest request);
        bool Remove(VMRemoveAttachmentRequest request);
        VMAttachment Update(VMUpdateAttachmentRequest request);
    }
}
