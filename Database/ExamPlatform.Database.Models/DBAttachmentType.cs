using System.Collections.Generic;

namespace ExamPlatform.Database.Models
{
    public class DBAttachmentType
	{
        public DBAttachmentType()
        {
            Attachments = new HashSet<DBAttachment>();
        }

        //Primary Key
		public int AttachmentTypeId { get; set; }

		public string Name { get; set; }

        //Multiple Foreign Key
        public virtual ICollection<DBAttachment> Attachments { get; set; }
    }
}
