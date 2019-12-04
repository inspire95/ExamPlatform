using System.Collections.Generic;

namespace ExamPlatform.Database.Models
{
    public class DBQuestionType
	{
        public DBQuestionType()
        {
            Questions = new HashSet<DBQuestion>();
        }

        //Primary key
		public int QuestionTypeId { get; set; }

		public string Name { get; set; }

        //Multiple Foreign Key
        public virtual ICollection<DBQuestion> Questions { get; set; }
	}
}
