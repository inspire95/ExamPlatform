using ExamPlatform.Database.Seeds;
using Microsoft.EntityFrameworkCore;

namespace ExamPlatform.Database
{
    public static class DataSeed
    {
        public static void DoSeed(ExamPlatformContext context)
        {
            AttachmentTypeSeed.DoSeed(context);
            CategoryTypeSeed.DoSeed(context);
            QuestionTypeSeed.DoSeed(context);
            RoleSeed.DoSeed(context);
            TestSummaryTypeSeed.DoSeed(context);
            UserTestStatusSeed.DoSeed(context);
            QuestionSeed.DoSeed(context);
            QuestionCategorySeed.DoSeed(context);
            UserSeed.DoSeed(context);
            UserRoleSeed.DoSeed(context);
            TestSeed.DoSeed(context);
            TestCategorySeed.DoSeed(context);
            UserTestSeed.DoSeed(context);
            TestQuestionSeed.DoSeed(context);
            AnswerSeed.DoSeed(context);
            AttachmentSeed.DoSeed(context);
            UserTestAnswerSeed.DoSeed(context);
        }

        public static void ResetSequence(ExamPlatformContext context, string sequenceName, int value)
        {
            var query = $"ALTER SEQUENCE public.\"{sequenceName}\" RESTART WITH {value.ToString()}";
            var result = context.Database.ExecuteSqlCommand(query);
        }
    }
}
