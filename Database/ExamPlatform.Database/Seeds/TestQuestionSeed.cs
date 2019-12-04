using ExamPlatform.Database.Models;
using System.Linq;

namespace ExamPlatform.Database.Seeds
{
    public static class TestQuestionSeed
    {
        public static void DoSeed(ExamPlatformContext context)
        {
            var test1 = new DBTestQuestion
            {
                TestId = 1,
                QuestionId = 1
            };
            var test2 = new DBTestQuestion
            {
                TestId = 1,
                QuestionId = 2
            };
            var test3 = new DBTestQuestion
            {
                TestId = 1,
                QuestionId = 3
            };
            var test4 = new DBTestQuestion
            {
                TestId = 1,
                QuestionId = 4
            };
            var test5 = new DBTestQuestion
            {
                TestId = 2,
                QuestionId = 5
            };
            var test6 = new DBTestQuestion
            {
                TestId = 2,
                QuestionId = 6
            };

            AddTestQuestion(test1, context);
            AddTestQuestion(test2, context);
            AddTestQuestion(test3, context);
            AddTestQuestion(test4, context);
            AddTestQuestion(test5, context);
            AddTestQuestion(test6, context);
        }

        private static void AddTestQuestion(DBTestQuestion question, ExamPlatformContext context)
        {
            var quesitonToChange = context.TestQuestions
                .Where(x => x.QuestionId == question.QuestionId && x.TestId == question.TestId)
                .FirstOrDefault();

            if (quesitonToChange == null)
            {
                context.TestQuestions.Add(question);
                context.SaveChanges();
            }
        }
    }
}
