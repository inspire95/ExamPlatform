using ExamPlatform.Database.Models;
using System;
using System.Linq;

namespace ExamPlatform.Database.Seeds
{
    public static class UserTestSeed
    {
        public static void DoSeed(ExamPlatformContext context)
        {
            var userTest1 = new DBUserTest
            {
                UserTestId = new Guid("C2FAE22D-9AFF-4424-9A72-0551FFDEE5E4"),
                TestId = 1,
                UserId = new Guid("7B6989A2-852F-4E2E-9148-1E7D8B54379F"),
                IsActive = true,
                StartDate = new DateTime(),
                EndDate = new DateTime().AddHours(1),
                AutoPointAquired = 5,
                ManualPointAquired = 0,
                TotalPointAquired = 5,
                TestSummaryTypeId = 2,
                UserTestStatusId = 4
            };
            var userTest2 = new DBUserTest
            {
                UserTestId = new Guid("F4B04592-20EA-4DE1-B96E-8145F2A079E7"),
                TestId = 1,
                UserId = new Guid("979E8876-9329-4031-9E1E-A956E2C0B6D8"),
                IsActive = true,
                StartDate = null,
                EndDate = null,
                AutoPointAquired = 0,
                ManualPointAquired = 0,
                TotalPointAquired = 0,
                TestSummaryTypeId = 1,
                UserTestStatusId = 1
            };

            AddUserTest(userTest1, context);
            AddUserTest(userTest2, context);
        }

        private static void AddUserTest(DBUserTest userTest, ExamPlatformContext context)
        {
            var userTestToChange = context.UserTests
                .Where(x => x.UserTestId == userTest.UserTestId)
                .FirstOrDefault();

            if (userTestToChange == null)
            {
                context.UserTests.Add(userTest);
            }
            else
            {
                userTestToChange.UserId = userTest.UserId;
                userTestToChange.TestId = userTest.TestId;
                userTestToChange.IsActive = userTest.IsActive;
                userTestToChange.TestSummaryTypeId = userTest.TestSummaryTypeId;
                userTestToChange.UserTestStatusId = userTest.UserTestStatusId;
                userTestToChange.TotalPointAquired = userTest.TotalPointAquired;
                userTestToChange.ManualPointAquired = userTest.ManualPointAquired;
                userTestToChange.AutoPointAquired = userTest.AutoPointAquired;
                userTestToChange.StartDate = userTest.StartDate;
                userTestToChange.EndDate = userTest.EndDate;
            }
            context.SaveChanges();
        }
    }
}
