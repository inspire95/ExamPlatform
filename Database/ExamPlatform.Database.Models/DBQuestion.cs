using System.Collections.Generic;

namespace ExamPlatform.Database.Models
{
    public class DBQuestion
	{
        public DBQuestion()
        {
            TestsQuestions = new HashSet<DBTestQuestion>();
            Anwsers = new HashSet<DBAnswer>();
            QuestionsCategories = new HashSet<DBQuestionCategory>();
            UserTestAnswers = new HashSet<DBUserTestAnswer>();
        }

        //Primary Key
		public int QuestionId { get; set; }

		public string Content { get; set; }
		public int PointsSum { get; set; }
		public bool IsActive { get; set; }

        //Foreign Key
        public int QuestionTypeId { get; set; }
		public virtual DBQuestionType QuestionType { get; set; }

        public int? AttachmentId { get; set; }
        public virtual DBAttachment Attachment { get; set; }

        //Multiple Foreign Key
        public virtual ICollection<DBTestQuestion> TestsQuestions { get; set; }
        public virtual ICollection<DBAnswer> Anwsers { get; set; }
        public virtual ICollection<DBQuestionCategory> QuestionsCategories { get; set; }
        public virtual ICollection<DBUserTestAnswer> UserTestAnswers { get; set; }

    }
}
