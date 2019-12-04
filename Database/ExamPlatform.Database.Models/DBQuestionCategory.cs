namespace ExamPlatform.Database.Models
{
    public class DBQuestionCategory
	{
        public DBQuestionCategory()
        { }

		//Many-to-May Relation
		public int CategoryTypeId { get; set; }
		public virtual DBCategoryType CategoryType { get; set; }

        public int QuestionId { get; set; }
		public virtual DBQuestion Question { get; set; }
	}
}
