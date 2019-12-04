using ExamPlatform.Database.Models;
using System.Linq;

namespace ExamPlatform.Database.Seeds
{
    public static class AttachmentSeed
    {
        public static void DoSeed(ExamPlatformContext context)
        {
            var attachment1 = new DBAttachment
            {
                AttachmentId = 1,
                AttachmentTypeId = 1,
                IsActive = true,
                QuestionId = 1,
                Text = "To jest jakis zalacznik",
                FilePath = "C:/Folder/Plik/zdj.png"
            };

            AddOrUpdateAttachment(attachment1, context);
            DataSeed.ResetSequence(context, "Attachments_AttachmentId_seq", context.Attachments.Max(x => x.AttachmentId) + 1);
        }

        private static void AddOrUpdateAttachment(DBAttachment attachment, ExamPlatformContext context)
        {
            var attachmentToChange = context.Attachments
                .Where(x => x.AttachmentId == attachment.AttachmentId)
                .FirstOrDefault();

            if (attachmentToChange == null)
            {
                context.Attachments.Add(attachment);
            }
            else
            {
                attachmentToChange.AttachmentId = attachment.AttachmentId;
                attachmentToChange.AttachmentTypeId = attachment.AttachmentTypeId;
                attachmentToChange.IsActive = attachment.IsActive;
                attachmentToChange.QuestionId = attachment.QuestionId;
                attachmentToChange.Text = attachment.Text;
                attachmentToChange.FilePath = attachment.FilePath;
            }
            context.SaveChanges();
        }
    }
}
