using ExamPlatform.Database.Models;
using System.Linq;

namespace ExamPlatform.Database.Seeds
{
    public static class CategoryTypeSeed
    {
        public static void DoSeed(ExamPlatformContext context)
        {

            var categoryType1 = new DBCategoryType
            {
                CategoryTypeId = 1,
                Name = "Programowanie",
                IsActive = true
            };
            var categoryType2 = new DBCategoryType
            {
                CategoryTypeId = 2,
                Name = "Górnictwo",
                IsActive = true
            };

            AddOrUpdateCategoryType(categoryType1, context);
            AddOrUpdateCategoryType(categoryType2, context);

            DataSeed.ResetSequence(context, "CategoryTypes_CategoryTypeId_seq", context.CategoryTypes.Max(x => x.CategoryTypeId) + 1);
        }

        private static void AddOrUpdateCategoryType(DBCategoryType categoryType, ExamPlatformContext context)
        {
            var catTypeToChange = context.CategoryTypes
                .Where(x => x.CategoryTypeId == categoryType.CategoryTypeId)
                .FirstOrDefault();

            if (catTypeToChange == null)
            {
                context.CategoryTypes.Add(categoryType);
            }
            else
            {
                catTypeToChange.Name = categoryType.Name;
            }
            context.SaveChanges();
        }
    }
}
