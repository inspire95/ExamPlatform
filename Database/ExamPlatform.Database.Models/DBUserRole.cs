using System;

namespace ExamPlatform.Database.Models
{
    public class DBUserRole
    {
        //Many-to-Many Relation
        public Guid UserId { get; set; }
        public virtual DBUser User { get; set; }

        public int RoleId { get; set; }
        public virtual DBRole Role { get; set; }
    }
}
