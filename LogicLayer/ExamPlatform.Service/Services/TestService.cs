using ExamPlatform.Database;
using ExamPlatform.Database.Models;
using ExamPlatform.Service.Interfaces;
using ExamPlatform.ViewModels.CategoryType;
using ExamPlatform.ViewModels.Question;
using ExamPlatform.ViewModels.Test;
using ExamPlatform.ViewModels.Test.Request;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPlatform.Service.Services
{
    public class TestService : ITestService
    {
        private readonly ExamPlatformContext _context;
        private readonly CategoryTypeService _categoryTypeService;
        private readonly QuestionService _questionService;

        public TestService(ExamPlatformContext context, CategoryTypeService categoryTypeService, QuestionService questionService)
        {
            _context = context;
            _categoryTypeService = categoryTypeService;
            _questionService = questionService;
        }

        public List<VMTestListItem> GetAll(VMGetTestsRequest vmRequest)
        {
            var tests = _context.Tests.Where(y => y.IsActive == true)
                .Select(x => new VMTestListItem
                {
                    TestId = x.TestId,
                    Name = x.Name,
                    TestCategories = x.TestsCategories.Select(z => new VMCategoryTypeItemList
                    {
                        Name = z.CategoryType.Name,
                        CategoryTypeId = z.CategoryTypeId
                    }).ToList(),
                    TotalPointSum = x.TotalPointSum

                }).ToList();
            return tests;
        }

        public VMTestDetails Get(VMGetTestDetailsRequest vmRequest)
        {
            var test = _context.Tests
                .Where(x => x.TestId == vmRequest.TestId)
                .Select(x => new VMTestDetails
                {
                    TestId = x.TestId,
                    Name = x.Name,
                    Content = x.Content,
                    Time = x.Time,
                    TotalPointSum = x.TotalPointSum,
                    RequiredPercentage = x.RequiredPercentage,
                    TestCategories = x.TestsCategories.Select(z => new VMCategoryTypeItemList
                    {
                        Name = z.CategoryType.Name,
                        CategoryTypeId = z.CategoryTypeId
                    }).ToList(),
                    TestQuestionIds = x.TestsQuestions.Select(y => y.QuestionId).ToList()
                }).FirstOrDefault();

            if (test == null)
            {
                throw new Exception("Not Found");
            }
            return test;
        }

        public VMTestDetails Create(VMCreateTestRequest vmRequest)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var newTest = new DBTest
                    {
                        Name = vmRequest.Name,
                        Content = vmRequest.Content,
                        Time = vmRequest.Time,
                        RequiredPercentage = vmRequest.RequiredPercentage,
                        IsActive = true
                    };

                    _context.Tests.Add(newTest);
                    _context.SaveChanges();
                    _categoryTypeService.AssignCategoryToTest(newTest.TestId, vmRequest.TestCategories);

                    var test = new VMTestDetails
                    {
                        TestId = newTest.TestId,
                        Name = newTest.Name,
                        Content = newTest.Content,
                        Time = newTest.Time,
                        RequiredPercentage = newTest.RequiredPercentage,
                        TotalPointSum = newTest.TotalPointSum,
                        TestQuestionIds = newTest.TestsQuestions.Select(y => y.QuestionId).ToList()
                    };
                    transaction.Commit();
                    return test;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
        public VMTestDetails Generate(VMGenerateTestRequest vmRequest)
        {
           List<int> testQuestionIds = new List<int>();
           if (vmRequest != null)
            {
                var test = new DBTest
                {
                    Name = vmRequest.Name,
                    Content = "Test został wygenerowany automatycznie",
                    Time = vmRequest.Time,
                    RequiredPercentage = vmRequest.RequiredPercentage,
                    IsActive = true
                };

                List<VMCategoryTypeItemList> categories = new List<VMCategoryTypeItemList>();

                foreach (var item in vmRequest.TestCategories)
                {
                    var category = _context.CategoryTypes.Where(y => y.CategoryTypeId == item)
                   .Select(y => new VMCategoryTypeItemList
                   {
                    CategoryTypeId = y.CategoryTypeId,
                    Name = y.Name,
                  }).FirstOrDefault();

                    categories.Add(category);
                }

                _context.Tests.Add(test);
               _context.SaveChanges();
                _categoryTypeService.AssignCategoryToTest(test.TestId, categories);

                List<VMQuestion> openQuesitons = new List<VMQuestion>();
                foreach (var item in vmRequest.TestCategories)
                {
                   var openquestions = _questionService.DrawOpenQuestions(vmRequest.OpenQuestion, item);
                    openQuesitons.AddRange(openquestions);
                }

               foreach (var item in openQuesitons)
                {
                    testQuestionIds.Add(item.QuestionId);
                }
                List<VMQuestion> closedQuestions = new List<VMQuestion>();
               foreach (var item in vmRequest.TestCategories)
               {
                    var closedquestions = _questionService.DrawClosedQuestions(vmRequest.ClosedQuestion, item);
                    closedQuestions.AddRange(closedquestions);
              }
               foreach (var item in closedQuestions)
               {
                   testQuestionIds.Add(item.QuestionId);
               }               _questionService.AssignQuestionToTest(test.TestId, testQuestionIds);
               return new VMTestDetails
               {
                   TestId =test.TestId,
                   Name = test.Name,
                   Content = test.Content,
                   Time = test.Time,
                   TotalPointSum = test.TotalPointSum,
                    TestQuestionIds = test.TestsQuestions.Select(y => y.QuestionId).ToList()
                };
            }
            throw new Exception("Not found");
        }

        public bool Remove(VMRemoveTestRequest vmRequest)
        {
            var test = _context.Tests
                .Where(t => t.TestId == vmRequest.TestId)
                .FirstOrDefault();

            if (test != null)
            {
                test.IsActive = false;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public VMTestDetails Update(VMUpdateTestRequest vmRequest)
        {
            var dbTest = _context.Tests
                .Where(t => t.TestId == vmRequest.TestId)
                .FirstOrDefault();

            if (dbTest == null)
            {
                throw new Exception("Test could not be found.");
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _questionService.AssignQuestionToTest(dbTest.TestId, vmRequest.TestQuestionIds);
                    _categoryTypeService.AssignCategoryToTest(dbTest.TestId, vmRequest.TestCategories);

                    dbTest.Name = vmRequest.Name;
                    dbTest.Content = vmRequest.Content;
                    dbTest.Time = vmRequest.Time;
                    dbTest.RequiredPercentage = vmRequest.RequiredPercentage;
                    dbTest.TotalPointSum = vmRequest.TotalPointSum;
                    _context.SaveChanges();

                    var test = new VMTestDetails
                    {
                        TestId = dbTest.TestId,
                        Name = dbTest.Name,
                        Content = dbTest.Content,
                        Time = dbTest.Time,
                        RequiredPercentage = dbTest.RequiredPercentage,
                        TotalPointSum = dbTest.TotalPointSum,
                        TestQuestionIds = dbTest.TestsQuestions.Select(y => y.QuestionId).ToList()
                    };

                    transaction.Commit();
                    return test;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
    }
}
