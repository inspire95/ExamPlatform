using ExamPlatform.Database.Models;
using ExamPlatform.Globals.Enum;
using System.Linq;

namespace ExamPlatform.Database.Seeds
{
    public static class QuestionSeed
    {
        public static void DoSeed(ExamPlatformContext context)
        {
            var question1 = new DBQuestion
            {
                QuestionId = 1,
                Content = "Czym jest dziedziczenie?",
                PointsSum = 2,
                IsActive = true,
                QuestionTypeId = (int)QuestionTypeEnum.CheckBox
            };
            var question2 = new DBQuestion
            {
                QuestionId = 2,
                Content = "Czym różni się klasa abstrakcyjna od interfejsu?",
                PointsSum = 3,
                IsActive = true,
                QuestionTypeId = (int)QuestionTypeEnum.TextBox
            };
            var question3 = new DBQuestion
            {
                QuestionId = 3,
                Content = "Gdzie się podziało pytanie o QuestionId = 3?",
                PointsSum = 1,
                IsActive = true,
                QuestionTypeId = (int)QuestionTypeEnum.RadioButton
            };
            var question4 = new DBQuestion
            {
                QuestionId = 4,
                Content = "Jakie są modyfikatory dostępu w języku C#?",
                PointsSum = 1,
                IsActive = true,
                QuestionTypeId = (int)QuestionTypeEnum.RadioButton
            };
            var question5 = new DBQuestion
            {
                QuestionId = 5,
                Content = "Co to jest konstruktor?",
                PointsSum = 1,
                IsActive = true,
                QuestionTypeId = (int)QuestionTypeEnum.RadioButton
            };
            var question6 = new DBQuestion
            {
                QuestionId = 6,
                Content = "Co to jest wzorzec projektowy?",
                PointsSum = 1,
                IsActive = true,
                QuestionTypeId = (int)QuestionTypeEnum.RadioButton
            };

            AddOrUpdateQuestion(question1, context);
            AddOrUpdateQuestion(question2, context);
            AddOrUpdateQuestion(question3, context);
            AddOrUpdateQuestion(question4, context);
            AddOrUpdateQuestion(question5, context);
            AddOrUpdateQuestion(question6, context);

            DataSeed.ResetSequence(context, "Questions_QuestionId_seq", context.Questions.Max(x => x.QuestionId) + 1);
        }

        private static void AddOrUpdateQuestion(DBQuestion question, ExamPlatformContext context)
        {
            var quesitonToChange = context.Questions
                .Where(x => x.QuestionId == question.QuestionId)
                .FirstOrDefault();

            if (quesitonToChange == null)
            {
                context.Questions.Add(question);
            }
            else
            {
                quesitonToChange.PointsSum = question.PointsSum;
                quesitonToChange.IsActive = question.IsActive;
                quesitonToChange.Content = question.Content;
                quesitonToChange.QuestionTypeId = question.QuestionTypeId;
            }
            context.SaveChanges();
        }
    }
}
