using System.Collections.Generic;

namespace ExamPlatform.Database.Models
{
    public class DBAnswer
	{
        public DBAnswer()
        {
            UserTestAnswers = new HashSet<DBUserTestAnswer>();
        }
        //Primary Key
		public int AnswerId { get; set; }

		public int Points { get; set; }
		public string Content { get; set; }
        public bool IsCorrect { get; set; }

        //Foreign Key
        public int QuestionId { get; set; }
        public DBQuestion Question { get; set; }

        public virtual ICollection<DBUserTestAnswer> UserTestAnswers { get; set; }
    }
}
