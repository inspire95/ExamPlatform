using System.Collections.Generic;

namespace ExamPlatform.Database.Models
{
    public class DBTest
	{
		public DBTest()
		{
			TestsQuestions = new HashSet<DBTestQuestion>();
			TestsCategories = new HashSet<DBTestCategory>();
			UsersTests = new HashSet<DBUserTest>();
		}

		//Primary key
		public int TestId { get; set; }

		public string Name { get; set; }
		public string Content { get; set; }

		public int TotalPointSum { get; set; }
		public int Time { get; set; }
        public int RequiredPercentage { get; set; }

        public bool IsActive { get; set; }

		//Multiple Foreign Key
		public virtual ICollection<DBTestQuestion> TestsQuestions { get; set; }
		public virtual ICollection<DBTestCategory> TestsCategories { get; set; }
		public virtual ICollection<DBUserTest> UsersTests { get; set; }
	}
}
