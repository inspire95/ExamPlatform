using System.Collections.Generic;

namespace ExamPlatform.Database.Models
{
    public class DBTestSummaryType
    {
        public DBTestSummaryType()
        {
            UsersTests = new HashSet<DBUserTest>();
        }

        //Primary Key
        public int TestSummaryTypeId { get; set; }

        public string Name { get; set; }

        //Multiple Foreign Key
        public virtual ICollection<DBUserTest> UsersTests { get; set; }
    }
}
