using ExamPlatform.Database.Models;
using System.Linq;

namespace ExamPlatform.Database.Seeds
{
    public static class TestSeed
    {
        public static void DoSeed(ExamPlatformContext context)
        {
            var test1 = new DBTest
            {
                TestId = 1,
                Name = "Test z wiedzy podstawowej",
                Content = "Super opis dla super testu",
                Time = 90,
                RequiredPercentage = 50,
                IsActive = true,
                TotalPointSum = 5
            };
            var test2 = new DBTest
            {
                TestId = 2,
                Name = "Test z wiedzy zaawansowanej",
                Content = "Słaby opis dla słabego testu",
                Time = 60,
                RequiredPercentage = 50,
                IsActive = true,
                TotalPointSum = 3
            };

            AddOrUpdateTest(test1, context);
            AddOrUpdateTest(test2, context);

            DataSeed.ResetSequence(context, "Tests_TestId_seq", context.Tests.Max(x => x.TestId) + 1);
        }

        private static void AddOrUpdateTest(DBTest test, ExamPlatformContext context)
        {
            var testToChange = context.Tests
                .Where(x => x.TestId == test.TestId)
                .FirstOrDefault();

            if (testToChange == null)
            {
                context.Tests.Add(test);
            }
            else
            {
                testToChange.Name = test.Name;
                testToChange.IsActive = test.IsActive;
                testToChange.Content = test.Content;
                testToChange.TotalPointSum = test.TotalPointSum;
                testToChange.Time = test.Time;
            }
            context.SaveChanges();
        }
    }
}
