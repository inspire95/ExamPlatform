using System.Collections.Generic;

namespace ExamPlatform.Database.Models
{
    public class DBCategoryType
	{
        public DBCategoryType()
        {
            this.QuestionsCategories = new HashSet<DBQuestionCategory>();
            this.TestsCategories = new HashSet<DBTestCategory>();
        }

        //Primary Key
		public int CategoryTypeId { get; set; }
        public bool IsActive { get; set; }  
		public string Name { get; set; }

        //Multiple Foreign Key
        public virtual ICollection<DBQuestionCategory> QuestionsCategories { get; set; }
        public virtual ICollection<DBTestCategory> TestsCategories { get; set; }
    }
}
