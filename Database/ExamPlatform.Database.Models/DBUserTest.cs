using System;
using System.Collections.Generic;

namespace ExamPlatform.Database.Models
{
    public class DBUserTest
    {
        public DBUserTest()
        {
            UserTestAnswers = new HashSet<DBUserTestAnswer>();
        }
        // Primary key
        public Guid UserTestId { get; set; }

        public int TotalPointAquired { get; set; }
        public int AutoPointAquired { get; set; }
        public int ManualPointAquired { get; set; }
        public bool IsActive { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        //Single Foreign Keys
        public int TestSummaryTypeId { get; set; }
        public virtual DBTestSummaryType TestSummaryType { get; set; }

        public int UserTestStatusId { get; set; }
        public virtual DBUserTestStatus UserTestStatus { get; set; }

        public Guid UserId { get; set; }
        public virtual DBUser User { get; set; }

        public int TestId { get; set; }
        public virtual DBTest Test { get; set; }

        public ICollection<DBUserTestAnswer> UserTestAnswers { get; set; }

    }
}
