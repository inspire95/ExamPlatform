namespace ExamPlatform.Database.Models
{
    public class DBTestQuestion
	{
        //Many-to-Many Relation
		public int QuestionId { get; set; }
        public virtual DBQuestion Question { get; set; }

		public int TestId { get; set; }
        public virtual DBTest Test { get; set; }
	}
}
