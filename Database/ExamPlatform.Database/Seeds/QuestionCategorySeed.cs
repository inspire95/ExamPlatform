using ExamPlatform.Database.Models;
using System.Linq;

namespace ExamPlatform.Database.Seeds
{
    public static class QuestionCategorySeed
    {
        public static void DoSeed(ExamPlatformContext context)
        {
            var questionCat1 = new DBQuestionCategory
            {
                CategoryTypeId = 1,
                QuestionId = 1
            };
            var questionCat2 = new DBQuestionCategory
            {
                CategoryTypeId = 1,
                QuestionId = 2
            };
            var questionCat3 = new DBQuestionCategory
            {
                CategoryTypeId = 1,
                QuestionId = 3,
            };
            var questionCat4 = new DBQuestionCategory
            {
                CategoryTypeId = 1,
                QuestionId = 4
            };
            var questionCat5 = new DBQuestionCategory
            {
                CategoryTypeId = 1,
                QuestionId = 5
            };
            var questionCat6 = new DBQuestionCategory
            {
                CategoryTypeId = 1,
                QuestionId = 6
            };

            AddQuestionCategory(questionCat1, context);
            AddQuestionCategory(questionCat2, context);
            AddQuestionCategory(questionCat3, context);
            AddQuestionCategory(questionCat4, context);
            AddQuestionCategory(questionCat5, context);
            AddQuestionCategory(questionCat6, context);
        }

        private static void AddQuestionCategory(DBQuestionCategory questionCategory, ExamPlatformContext context)
        {
            var answerToChange = context.QuestionCategories
                .Where(x => x.CategoryTypeId == questionCategory.CategoryTypeId && x.QuestionId == questionCategory.QuestionId)
                .FirstOrDefault();

            if (answerToChange == null)
            {
                context.QuestionCategories.Add(questionCategory);
                context.SaveChanges();
            }
        }
    }
}
