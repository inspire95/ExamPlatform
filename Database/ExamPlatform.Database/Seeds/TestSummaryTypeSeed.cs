using ExamPlatform.Database.Models;
using ExamPlatform.Globals.Enum;
using System;
using System.Linq;

namespace ExamPlatform.Database.Seeds
{
    public static class TestSummaryTypeSeed
    {
        public static void DoSeed(ExamPlatformContext context)
        {
            foreach (TestSummaryTypeEnum tsType in Enum.GetValues(typeof(TestSummaryTypeEnum)))
            {
                if ((int)tsType == 0) continue;
                var testSummType = new DBTestSummaryType
                {
                    TestSummaryTypeId = (int)tsType,
                    Name = tsType.ToString()
                };

                AddOrUpdateTestSummaryType(testSummType, context);
            }
            DataSeed.ResetSequence(context, "TestSummaryTypes_TestSummaryTypeId_seq", context.TestSummaryTypes.Max(x => x.TestSummaryTypeId) + 1);
        }

        private static void AddOrUpdateTestSummaryType(DBTestSummaryType testSummaryType, ExamPlatformContext context)
        {
            var testSummTypeToChange = context.TestSummaryTypes
                .Where(x => x.TestSummaryTypeId == testSummaryType.TestSummaryTypeId)
                .FirstOrDefault();

            if (testSummTypeToChange == null)
            {
                context.TestSummaryTypes.Add(testSummaryType);
            }
            else
            {
                testSummTypeToChange.Name = testSummaryType.Name;
            }
            context.SaveChanges();
        }
    }
}
