using ExamPlatform.Database;
using ExamPlatform.Database.Models;
using ExamPlatform.Service.Interfaces;
using ExamPlatform.ViewModels.Attachment;
using ExamPlatform.ViewModels.Attachment.Request;
using System;
using System.Linq;

namespace ExamPlatform.Service.Services
{
    public class AttachmentService : IAttachmentService
    {
        private readonly ExamPlatformContext _context;

        public AttachmentService(ExamPlatformContext context)
        {
            _context = context;
        }

        public VMAttachment Get(VMGetAttachmentDetailsRequest request)
        {
            var dbAttachment = _context.Attachments
                 .Where(m => m.AttachmentId == request.AttachmentId)
                 .FirstOrDefault();

            if (dbAttachment == null)
            {
                throw new Exception("Attachment could not be found.");
            }

            var attachment = new VMAttachment
            {
                AttachmentId = dbAttachment.AttachmentId,
                Text = dbAttachment.Text,
                FilePath = dbAttachment.FilePath,
                IsActive = dbAttachment.IsActive,
                AttachmentTypeName = dbAttachment.AttachmentType.Name,
                QuestionId = dbAttachment.QuestionId
            };

            return attachment;
        }

        public VMAttachment Create(VMCreateAttechmentRequest request)
        {
            var newAttachment = new DBAttachment
            {
                Text = request.Text,
                FilePath = request.FilePath,
                IsActive = true,
                AttachmentTypeId = request.AttachmentTypeId,
                QuestionId = request.QuestionId
            };

            _context.Attachments.Add(newAttachment);
            _context.SaveChanges();

            var attachment = new VMAttachment
            {
                AttachmentId = newAttachment.AttachmentId,
                Text = newAttachment.Text,
                FilePath = newAttachment.FilePath,
                AttachmentTypeName = newAttachment.AttachmentType.Name,
                QuestionId = newAttachment.QuestionId
            };

            return attachment;
        }

        public bool Remove(VMRemoveAttachmentRequest request)
        {
            var attachment = _context.Attachments
                .Where(m => m.AttachmentId == request.AttachmentId)
                .FirstOrDefault();

            if (attachment == null)
            {
                return false;
            }

            attachment.IsActive = false;
            _context.SaveChanges();
            return true;
        }

        public VMAttachment Update(VMUpdateAttachmentRequest request)
        {
            var dbAttachment = _context.Attachments
                 .Where(m => m.AttachmentId == request.AttachmentId)
                 .FirstOrDefault();

            if (dbAttachment == null)
            {
                throw new Exception("Attachment could not be found.");
            }

            dbAttachment.AttachmentId = request.AttachmentId;
            dbAttachment.Text = request.Text;
            dbAttachment.FilePath = request.FilePath;
            dbAttachment.AttachmentTypeId = request.AttachmentTypeId;
            dbAttachment.QuestionId = request.QuestionId;
            _context.SaveChanges();

            var attachment = new VMAttachment
            {
                AttachmentId = dbAttachment.AttachmentId,
                Text = dbAttachment.Text,
                IsActive = dbAttachment.IsActive,
                FilePath = dbAttachment.FilePath,
                AttachmentTypeName = dbAttachment.AttachmentType.Name,
                QuestionId = dbAttachment.QuestionId
            };

            return attachment;
        }
    }
}
