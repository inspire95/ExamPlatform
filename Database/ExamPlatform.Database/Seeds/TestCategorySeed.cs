using ExamPlatform.Database.Models;
using System.Linq;

namespace ExamPlatform.Database.Seeds
{
    public static class TestCategorySeed
    {
        public static void DoSeed(ExamPlatformContext context)
        {
            var testCategory1 = new DBTestCategory
            {
                TestId = 1,
                CategoryTypeId = 1
            };
            var testCategory2 = new DBTestCategory
            {
                TestId = 1,
                CategoryTypeId = 2
            };
            var testCategory3 = new DBTestCategory
            {
                TestId = 2,
                CategoryTypeId = 2
            };

            AddTestCategory(testCategory1, context);
            AddTestCategory(testCategory2, context);
            AddTestCategory(testCategory3, context);
        }

        private static void AddTestCategory(DBTestCategory testCategory, ExamPlatformContext context)
        {
            var answerToChange = context.TestCategories
                .Where(x => x.CategoryTypeId == testCategory.CategoryTypeId && x.TestId == testCategory.TestId)
                .FirstOrDefault();

            if (answerToChange == null)
            {
                context.TestCategories.Add(testCategory);
                context.SaveChanges();
            }
        }
    }
}