using ExamPlatform.Database;
using ExamPlatform.Database.Models;
using ExamPlatform.Service.Interfaces;
using ExamPlatform.ViewModels.CategoryType;
using ExamPlatform.ViewModels.CategoryType.Request;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPlatform.Service.Services
{
    public class CategoryTypeService : ICategoryTypeService
    {
        private readonly ExamPlatformContext _context;

        public CategoryTypeService(ExamPlatformContext context)
        {
            _context = context;
        }

        public List<VMCategoryTypeItemList> GetAll(VMGetCategoryTypeListRequest request)
        {
            var types = _context.CategoryTypes.Where(x => x.IsActive == true)
                .Select(x => new VMCategoryTypeItemList
                {
                    CategoryTypeId = x.CategoryTypeId,
                    Name = x.Name,
                }).ToList();

            return types;
        }

        public VMCategoryTypeDetails Get(VMGetCategoryTypeDetailsRequest request)
        {
            var dbCategoryType = _context.CategoryTypes
                .Where(m => m.CategoryTypeId == request.CategoryTypeId)
                .FirstOrDefault();

            if (dbCategoryType == null)
            {
                throw new Exception("Category type could not be found.");
            }

            var categoryType = new VMCategoryTypeDetails
            {
                CategoryTypeId = dbCategoryType.CategoryTypeId,
                Name = dbCategoryType.Name
            };

            return categoryType;
        }

        public VMCategoryTypeDetails Create(VMCreateCategoryTypeRequest request)
        {
            var dbCategoryType = new DBCategoryType
            {
                Name = request.Name,
                IsActive = true
            };

            _context.CategoryTypes.Add(dbCategoryType);
            _context.SaveChanges();

            var categoryType = new VMCategoryTypeDetails
            {
                CategoryTypeId = dbCategoryType.CategoryTypeId,
                Name = dbCategoryType.Name
            };

            return categoryType;
        }

        public bool Remove(VMRemoveCategoryTypeRequest request)
        {
            var categoryType = _context.CategoryTypes
                .Where(m => m.CategoryTypeId == request.CategoryTypeId)
                .FirstOrDefault();

            if (categoryType == null)
            {
                return false;
            }

            categoryType.IsActive = false;
            _context.SaveChanges();

            return true;
        }

        public VMCategoryTypeDetails Update(VMUpdateCategoryTypeRequest request)
        {

            var dbCategoryType = _context.CategoryTypes
                .Where(m => m.CategoryTypeId == request.CategoryTypeId)
                .FirstOrDefault();

            if (dbCategoryType == null)
            {
                throw new Exception("Category type could not be found.");
            }

            dbCategoryType.CategoryTypeId = request.CategoryTypeId;
            dbCategoryType.Name = request.Name;
            _context.SaveChanges();

            var categoryType = new VMCategoryTypeDetails
            {
                CategoryTypeId = dbCategoryType.CategoryTypeId,
                Name = dbCategoryType.Name
            };

            categoryType.IsActive = true;
            return categoryType;
        }

        public bool AssignCategoryToQuestion(int questionId, ICollection<int> categoryTypes)
        {
            var toClear = _context.QuestionCategories.Where(x => x.QuestionId == questionId).ToList();
            if (toClear != null)
            {
                foreach (var item in toClear)
                {
                    _context.QuestionCategories.Remove(item);
                }
            }
            if (categoryTypes != null)
            {
                foreach (int categoryTypeId in categoryTypes)
                {
                    var questionCategory = new DBQuestionCategory
                    {
                        QuestionId = questionId,
                        CategoryTypeId = categoryTypeId
                    };
                    _context.QuestionCategories.Add(questionCategory);
                }
            }
            _context.SaveChanges();
            return true;
        }

        public bool AssignCategoryToTest(int testId, ICollection<VMCategoryTypeItemList> categoryTypes)
        {

            var toClear = _context.TestCategories.Where(x => x.TestId == testId).ToList();
            if (toClear != null)
            {
                foreach (var item in toClear)
                {
                    _context.TestCategories.Remove(item);
                }
            }
            if (categoryTypes != null)
            {
                foreach (VMCategoryTypeItemList categoryType in categoryTypes)
                {
                    var testCategory = new DBTestCategory
                    {
                        TestId = testId,
                        CategoryTypeId = categoryType.CategoryTypeId
                    };
                    _context.TestCategories.Add(testCategory);
                }
            }
            _context.SaveChanges();
            return true;
        }
    }
}
