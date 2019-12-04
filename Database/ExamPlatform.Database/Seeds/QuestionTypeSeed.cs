using ExamPlatform.Database.Models;
using ExamPlatform.Globals.Enum;
using System;
using System.Linq;

namespace ExamPlatform.Database.Seeds
{
    public static class QuestionTypeSeed
    {
        public static void DoSeed(ExamPlatformContext context)
        {
            foreach (QuestionTypeEnum qType in Enum.GetValues(typeof(QuestionTypeEnum)))
            {
                if ((int)qType == 0) continue;
                var questionType = new DBQuestionType
                {
                    QuestionTypeId = (int)qType,
                    Name = qType.ToString()
                };

                AddOrUpdateQuestionType(questionType, context);
            }
            DataSeed.ResetSequence(context, "QuestionTypes_QuestionTypeId_seq", context.QuestionTypes.Max(x => x.QuestionTypeId) + 1);
        }

        private static void AddOrUpdateQuestionType(DBQuestionType questionType, ExamPlatformContext context)
        {
            var questionTypeToChange = context.QuestionTypes
                .Where(x => x.QuestionTypeId == questionType.QuestionTypeId)
                .FirstOrDefault();

            if (questionTypeToChange == null)
            {
                context.QuestionTypes.Add(questionType);
            }
            else
            {
                questionTypeToChange.Name = questionType.Name;
            }
            context.SaveChanges();
        }
    }
}
