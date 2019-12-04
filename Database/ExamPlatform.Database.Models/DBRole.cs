using System.Collections.Generic;

namespace ExamPlatform.Database.Models
{
    public class DBRole
    {
        public DBRole()
        {
            UsersRoles = new HashSet<DBUserRole>();
        }

        //Primary Key
        public int RoleId { get; set; }

        public string Name { get; set; }

        //Foreign Key
        public virtual ICollection<DBUserRole> UsersRoles { get; set; }
    }
}
