using System;

namespace ExamPlatform.Database.Models
{
    public class DBUserTestAnswer
    {
        public int UserTestAnswerId { get; set; }

        public int QuestionId { get; set; }
        public virtual DBQuestion Question { get; set; }

        public int? AnswerId { get; set; }
        public virtual DBAnswer Answer { get; set; }

        public Guid UserTestId { get; set; }
        public virtual DBUserTest UserTest { get; set; }

        public string Content { get; set; }
        public int? PointsForOpenQuestion { get; set; }
    }
}
