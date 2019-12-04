using ExamPlatform.Database.Models;
using ExamPlatform.Globals.Enum;
using System;
using System.Linq;

namespace ExamPlatform.Database.Seeds
{
    public static class AttachmentTypeSeed
    {
        public static void DoSeed(ExamPlatformContext context)
        {
            foreach (AttachmentTypeEnum aType in Enum.GetValues(typeof(AttachmentTypeEnum)))
            {
                if ((int)aType == 0) continue;
                var attachmentType = new DBAttachmentType
                {
                    AttachmentTypeId = (int)aType,
                    Name = aType.ToString()
                };

                AddOrUpdateAttachmentType(attachmentType, context);
            }
            DataSeed.ResetSequence(context, "AttachmentTypes_AttachmentTypeId_seq", context.AttachementTypes.Max(x => x.AttachmentTypeId) + 1);
        }
        private static void AddOrUpdateAttachmentType(DBAttachmentType attachmentType, ExamPlatformContext context)
        {
            var aTypeToChange = context.AttachementTypes
                .Where(x => x.AttachmentTypeId == attachmentType.AttachmentTypeId)
                .FirstOrDefault();

            if (aTypeToChange == null)
            {
                context.AttachementTypes.Add(attachmentType);
            }
            else
            {
                aTypeToChange.Name = attachmentType.Name;
            }
            context.SaveChanges();
        }
    }
}
