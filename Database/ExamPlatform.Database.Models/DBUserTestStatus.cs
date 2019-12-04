using System.Collections.Generic;

namespace ExamPlatform.Database.Models
{
    public class DBUserTestStatus
    {
        public DBUserTestStatus()
        {
            UsersTests = new HashSet<DBUserTest>();
        }

        //Primary key
        public int UserTestStatusId { get; set; }

        public string Name { get; set; }

        //Foreign key
        public ICollection<DBUserTest> UsersTests { get; set; }
    }

}
