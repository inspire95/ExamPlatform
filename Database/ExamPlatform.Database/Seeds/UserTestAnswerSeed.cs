using ExamPlatform.Database.Models;
using System;
using System.Linq;

namespace ExamPlatform.Database.Seeds
{
    public static class UserTestAnswerSeed
    {
        public static void DoSeed(ExamPlatformContext context)
        {
            var userTestAnswer1 = new DBUserTestAnswer
            {
                UserTestAnswerId = 1,
                UserTestId = new Guid("C2FAE22D-9AFF-4424-9A72-0551FFDEE5E4"),
                AnswerId = 3,
                QuestionId = 1,
                Content = null,
                PointsForOpenQuestion = null
            };

            var userTestAnswer2 = new DBUserTestAnswer
            {
                UserTestAnswerId = 2,
                UserTestId = new Guid("C2FAE22D-9AFF-4424-9A72-0551FFDEE5E4"),
                AnswerId = null,
                QuestionId = 2,
                Content = "Odpowidziałem",
                PointsForOpenQuestion = 1
            };

            var userTestAnswer3 = new DBUserTestAnswer
            {
                UserTestAnswerId = 3,
                UserTestId = new Guid("C2FAE22D-9AFF-4424-9A72-0551FFDEE5E4"),
                AnswerId = 6,
                QuestionId = 3,
                Content = null,
                PointsForOpenQuestion = null
            };

            var userTestAnswer4 = new DBUserTestAnswer
            {
                UserTestAnswerId = 4,
                UserTestId = new Guid("C2FAE22D-9AFF-4424-9A72-0551FFDEE5E4"),
                AnswerId = 9,
                QuestionId = 4,
                Content = null,
                PointsForOpenQuestion = null
            };

            var userTestAnswer5 = new DBUserTestAnswer
            {
                UserTestAnswerId = 5,
                UserTestId = new Guid("C2FAE22D-9AFF-4424-9A72-0551FFDEE5E4"),
                AnswerId = 12,
                QuestionId = 5,
                Content = null,
                PointsForOpenQuestion = null
            };

            AddUserTestAnswer(userTestAnswer1, context);
            AddUserTestAnswer(userTestAnswer2, context);
            AddUserTestAnswer(userTestAnswer3, context);
            AddUserTestAnswer(userTestAnswer4, context);
            AddUserTestAnswer(userTestAnswer5, context);

            DataSeed.ResetSequence(context, "UserTestAnswer_UserTestAnswerId_seq", context.UserTestAnswers.Max(x => x.UserTestAnswerId) + 1);
        }

        private static void AddUserTestAnswer(DBUserTestAnswer userTestAnswer, ExamPlatformContext context)
        {
            var userTestAnswerToChange = context.UserTestAnswers
                .Where(x => x.UserTestAnswerId == userTestAnswer.UserTestAnswerId)
                .FirstOrDefault();

            if (userTestAnswerToChange == null)
            {
                context.UserTestAnswers.Add(userTestAnswer);
            }
            else
            {
                userTestAnswerToChange.UserTestId = userTestAnswer.UserTestId;
                userTestAnswerToChange.AnswerId = userTestAnswer.AnswerId;
                userTestAnswerToChange.QuestionId = userTestAnswer.QuestionId;
                userTestAnswerToChange.Content = userTestAnswer.Content;
                userTestAnswerToChange.PointsForOpenQuestion = userTestAnswer.PointsForOpenQuestion;
            }
            context.SaveChanges();
        }
    }
}
