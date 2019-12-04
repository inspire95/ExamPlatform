namespace ExamPlatform.Database.Models
{
    public class DBAttachment
	{
        //Primary Key
		public int AttachmentId { get; set; }

		public string Text { get; set; }
		public string FilePath { get; set; }
        public bool IsActive { get; set; }

        //Single Foreign Keys
        public int AttachmentTypeId { get; set; }
        public virtual DBAttachmentType AttachmentType { get; set; }

        public int QuestionId { get; set; }
        public virtual DBQuestion Question { get; set; }
	}
}
