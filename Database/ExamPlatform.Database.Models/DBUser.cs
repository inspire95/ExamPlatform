using System;
using System.Collections.Generic;

namespace ExamPlatform.Database.Models
{
    public class DBUser
    {
        public DBUser()
        {
            UsersRoles = new HashSet<DBUserRole>();
            UsersTests = new HashSet<DBUserTest>();
        }

        //Primary Key
        public Guid UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public bool IsActive { get; set; }

        //Multiple Foreign Key
        public virtual ICollection<DBUserRole> UsersRoles { get; set; }
        public virtual ICollection<DBUserTest> UsersTests { get; set; }
    }
}
