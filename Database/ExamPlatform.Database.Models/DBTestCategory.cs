using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPlatform.Database.Models
{
	public class DBTestCategory
	{
        //Many-to-Many Relation
        public int CategoryTypeId { get; set; }
		public virtual DBCategoryType CategoryType { get; set; }

        public int TestId { get; set; }
		public virtual DBTest Test { get; set; }
	}
}
