using ExamPlatform.Database.Models;
using ExamPlatform.Globals.Enum;
using System;
using System.Linq;

namespace ExamPlatform.Database.Seeds
{
    public static class UserTestStatusSeed
    {
        public static void DoSeed(ExamPlatformContext context)
        {
            foreach (UserTestStatusEnum utType in Enum.GetValues(typeof(UserTestStatusEnum)))
            {
                if ((int)utType == 0) continue;
                var userTestStarus = new DBUserTestStatus
                {
                    UserTestStatusId = (int)utType,
                    Name = utType.ToString()
                };

                AddOrUpdateUserTestStatus(userTestStarus, context);
            }
            DataSeed.ResetSequence(context, "UserTestStatuses_UserTestStatusId_seq", context.UserTestStatuses.Max(x => x.UserTestStatusId) + 1);
        }

        private static void AddOrUpdateUserTestStatus(DBUserTestStatus userTestStatus, ExamPlatformContext context)
        {
            var utStatusToChange = context.UserTestStatuses
                .Where(x => x.UserTestStatusId == userTestStatus.UserTestStatusId)
                .FirstOrDefault();

            if (utStatusToChange == null)
            {
                context.UserTestStatuses.Add(userTestStatus);
            }
            else
            {
                utStatusToChange.Name = userTestStatus.Name;
            }
            context.SaveChanges();
        }
    }
}
