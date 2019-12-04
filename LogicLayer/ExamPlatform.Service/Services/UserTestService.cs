using ExamPlatform.Database;
using ExamPlatform.Database.Models;
using ExamPlatform.Service.Interfaces;
using ExamPlatform.ViewModels.CategoryType;
using ExamPlatform.ViewModels.UserTest;
using ExamPlatform.ViewModels.UserTest.Request;
using ExamPlatform.ViewModels.UserTestDetails;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ExamPlatform.Service.Services
{
    public class UserTestService : IUserTestService
    {
        private readonly ExamPlatformContext _context;
        public UserTestService(ExamPlatformContext context)
        {
            _context = context;
        }

        public List<VMUserTestItemList> GetAll(VMGetUserTestListRequest request)
        {
            var userTests = _context.UserTests
                .Where(x => x.UserId == request.UserId && x.IsActive == true)
                .Select(x => new VMUserTestItemList
                {
                    TestName = x.Test.Name,
                    UserTestId = x.UserTestId,
                    TestId = x.TestId,
                    UserTestStatusName = x.UserTestStatus.Name,
                    TestSummaryTypeName = x.TestSummaryType.Name,
                    TotalPointAquired = x.TotalPointAquired,
                    TestsCategories = x.Test.TestsCategories.Select(z => new VMCategoryTypeItemList
                    {
                        CategoryTypeId = z.CategoryTypeId,
                        Name = z.CategoryType.Name
                    }).ToList(),
                    StartDate = x.StartDate
                }).ToList();
            return userTests;
        }


        public VMUserTestDetails Get(VMGetUserTestDetailsRequest request)
        {
            var userTest = _context.UserTests
               .Where(x => x.UserTestId == request.UserTestId)
               .FirstOrDefault();

            if (userTest == null)
            {
                throw new Exception("User's test could not be found.");
            }

            var vmUserTest = new VMUserTestDetails
            {
                TestName = _context.Tests
                    .Where(y => y.TestId == userTest.TestId)
                    .Select(x => x.Name).FirstOrDefault(),
                UserTestId = userTest.UserTestId,
                TestId = userTest.TestId,
                UserId = userTest.UserId,
                UserTestStatusName = _context.UserTestStatuses
                    .Where(y => y.UserTestStatusId == userTest.UserTestStatusId)
                    .Select(x => x.Name).FirstOrDefault(),
                TestSummaryTypeName = _context.TestSummaryTypes
                    .Where(y => y.TestSummaryTypeId == userTest.TestSummaryTypeId)
                    .Select(x => x.Name).FirstOrDefault(),
                TotalPointAquired = userTest.TotalPointAquired,
                TestsCategories = _context.TestCategories
                    .Where(y => y.TestId == userTest.TestId)
                    .Select(z => new VMCategoryTypeItemList
                    {
                        CategoryTypeId = z.CategoryTypeId,
                        Name = z.CategoryType.Name
                    }).ToList(),
                StartDate = userTest.StartDate,
                EndDate = userTest.EndDate,
				TotalPointSum = _context.Tests
					.Where(y => y.TestId == userTest.TestId)
					.Select(x => x.TotalPointSum).FirstOrDefault()
            };

            return vmUserTest;
        }

        public VMUserTestDetails Create(VMCreateUserTestRequest request)
        {
            var userTest = new DBUserTest
            {
                TestId = request.TestId,
                UserId = request.UserId,
                IsActive = true,
                TestSummaryType = _context.TestSummaryTypes
                                .Where(x => x.TestSummaryTypeId == 1)
                                .FirstOrDefault(),
                UserTestStatus = _context.UserTestStatuses
                                .Where(x => x.UserTestStatusId == 1)
                                .FirstOrDefault()
            };

            _context.UserTests.Add(userTest);
            _context.SaveChanges();

            var vmUserTest = new VMUserTestDetails
            {
                TestName = _context.Tests
                   .Where(y => y.TestId == userTest.TestId)
                   .Select(x => x.Name).FirstOrDefault(),
                UserTestId = userTest.UserTestId,
                TestId = userTest.TestId,
                UserId = userTest.UserId,
                UserTestStatusName = _context.UserTestStatuses
                   .Where(y => y.UserTestStatusId == userTest.UserTestStatusId)
                   .Select(x => x.Name).FirstOrDefault(),
                TestSummaryTypeName = _context.TestSummaryTypes
                   .Where(y => y.TestSummaryTypeId == userTest.TestSummaryTypeId)
                   .Select(x => x.Name).FirstOrDefault(),
                TotalPointAquired = userTest.TotalPointAquired,
                TestsCategories = _context.TestCategories
                   .Where(y => y.TestId == userTest.TestId)
                   .Select(z => new VMCategoryTypeItemList
                   {
                       CategoryTypeId = z.CategoryTypeId,
                       Name = z.CategoryType.Name
                   }).ToList(),
                StartDate = userTest.StartDate,
                EndDate = userTest.EndDate
            };

            return vmUserTest;
        }

        public bool Remove(VMRemoveUserTestRequest request)
        {
            var userTest = _context.UserTests
                .Where(m => m.UserTestId == request.UserTestId)
                .FirstOrDefault();

            if (userTest == null)
            {
                return false;
            }

            userTest.IsActive = false;
            _context.SaveChanges();
            return true;
        }

        public bool StartUserTest(VMStartUserTestRequest request)
        {
            var userTest = _context.UserTests
              .Where(x => x.UserTestId == request.UserTestId)
              .FirstOrDefault();

            if (userTest != null)
            {
                userTest.UserTestStatus = _context.UserTestStatuses
                                         .Where(x => x.UserTestStatusId == 2)
                                         .FirstOrDefault();
                userTest.StartDate = request.StartDate;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public VMUserTestDetails FinishUserTest(VMFinishUserTestRequest request)
        {
            var userTest = _context.UserTests
              .Where(x => x.UserTestId == request.UserTestId)
              .FirstOrDefault();

            if (userTest != null)
            {
                var userTestAnswers = _context.UserTestAnswers
                    .Where(x => x.UserTestId == userTest.UserTestId)
                    .ToList();

                int autoAquiredPoints = 0;
                bool hasAnyTextBox = false;

                foreach (var userAnswer in userTestAnswers)
                {
                    var qType = _context.Questions
                        .Where(x => x.QuestionId == userAnswer.QuestionId)
                        .Select(x => x.QuestionTypeId).FirstOrDefault();

                    if (qType != 3)
                    {
                        var answerPoints = _context.Answers
                            .Where(x => x.AnswerId == userAnswer.AnswerId)
                            .Select(x => x.Points).FirstOrDefault();

                        autoAquiredPoints = autoAquiredPoints + answerPoints;
                    }
                    else
                    {
                        hasAnyTextBox = true;
                    }
                }

                if (hasAnyTextBox)
                {
                    userTest.UserTestStatus = _context.UserTestStatuses
                            .Where(x => x.UserTestStatusId == 3).FirstOrDefault();
                }
                else
                {
                    var test = _context.Tests
                        .Where(x => x.TestId == userTest.TestId).FirstOrDefault();

                    double aquiredPercentage = ((double)autoAquiredPoints / ((double)test.TotalPointSum)) * 100;
                    if (aquiredPercentage >= test.RequiredPercentage)
                    {
                        userTest.TestSummaryType = _context.TestSummaryTypes
                            .Where(x => x.TestSummaryTypeId == 2).FirstOrDefault();
                    }
                    else
                    {
                        userTest.TestSummaryType = _context.TestSummaryTypes
                            .Where(x => x.TestSummaryTypeId == 3).FirstOrDefault();
                    }
                    userTest.ManualPointAquired = 0;
                    userTest.TotalPointAquired = autoAquiredPoints;
                    userTest.UserTestStatus = _context.UserTestStatuses
                            .Where(x => x.UserTestStatusId == 4).FirstOrDefault();
                }
                userTest.AutoPointAquired = autoAquiredPoints;
                userTest.EndDate = request.EndDate;
                _context.SaveChanges();
            }

            var vmUserTest = new VMUserTestDetails
            {
                TestName = _context.Tests
                    .Where(y => y.TestId == userTest.TestId)
                    .Select(x => x.Name).FirstOrDefault(),
                UserTestId = userTest.UserTestId,
                TestId = userTest.TestId,
                UserId = userTest.UserId,
                UserTestStatusName = _context.UserTestStatuses
                    .Where(y => y.UserTestStatusId == userTest.UserTestStatusId)
                    .Select(x => x.Name).FirstOrDefault(),
                TestSummaryTypeName = _context.TestSummaryTypes
                    .Where(y => y.TestSummaryTypeId == userTest.TestSummaryTypeId)
                    .Select(x => x.Name).FirstOrDefault(),
                TotalPointAquired = userTest.TotalPointAquired,
                TestsCategories = _context.TestCategories
                    .Where(y => y.TestId == userTest.TestId)
                    .Select(z => new VMCategoryTypeItemList
                    {
                        CategoryTypeId = z.CategoryTypeId,
                        Name = z.CategoryType.Name
                    }).ToList(),
                StartDate = userTest.StartDate,
                EndDate = userTest.EndDate
            };

            return vmUserTest;
        }

        public VMUserTestDetails CheckSummaryUserTest(VMCheckSummaryUserTestRequest request)
        {
            var userTest = _context.UserTests
              .Where(x => x.UserTestId == request.UserTestId)
              .FirstOrDefault();

            if (userTest != null)
            {
                var userTestOpenAnswers = _context.UserTestAnswers
                    .Where(x => x.UserTestId == userTest.UserTestId && x.AnswerId == null)
                    .ToList();

                int manualAquiredPoints = 0;

                foreach (var userAnswer in userTestOpenAnswers)
                {
                    manualAquiredPoints = manualAquiredPoints + (int)userAnswer.PointsForOpenQuestion;
                }

                int totalAquiredPoints = manualAquiredPoints + userTest.AutoPointAquired;

                var test = _context.Tests
                        .Where(x => x.TestId == userTest.TestId).FirstOrDefault();


                double aquiredPercentage = ((double)totalAquiredPoints / ((double)test.TotalPointSum)) * 100;
                if (aquiredPercentage >= test.RequiredPercentage)
                {
                    userTest.TestSummaryType = _context.TestSummaryTypes
                        .Where(x => x.TestSummaryTypeId == 2).FirstOrDefault();
                }
                else
                {
                    userTest.TestSummaryType = _context.TestSummaryTypes
                        .Where(x => x.TestSummaryTypeId == 3).FirstOrDefault();
                }
                userTest.ManualPointAquired = manualAquiredPoints;
                userTest.TotalPointAquired = totalAquiredPoints;
                userTest.UserTestStatus = _context.UserTestStatuses
                        .Where(x => x.UserTestStatusId == 4).FirstOrDefault();

                _context.SaveChanges();
            }

            var vmUserTest = new VMUserTestDetails
            {
                TestName = _context.Tests
                   .Where(y => y.TestId == userTest.TestId)
                   .Select(x => x.Name).FirstOrDefault(),
                UserTestId = userTest.UserTestId,
                TestId = userTest.TestId,
                UserId = userTest.UserId,
                UserTestStatusName = _context.UserTestStatuses
                   .Where(y => y.UserTestStatusId == userTest.UserTestStatusId)
                   .Select(x => x.Name).FirstOrDefault(),
                TestSummaryTypeName = _context.TestSummaryTypes
                   .Where(y => y.TestSummaryTypeId == userTest.TestSummaryTypeId)
                   .Select(x => x.Name).FirstOrDefault(),
                TotalPointAquired = userTest.TotalPointAquired,
                TestsCategories = _context.TestCategories
                   .Where(y => y.TestId == userTest.TestId)
                   .Select(z => new VMCategoryTypeItemList
                   {
                       CategoryTypeId = z.CategoryTypeId,
                       Name = z.CategoryType.Name
                   }).ToList(),
                StartDate = userTest.StartDate,
                EndDate = userTest.EndDate
            };

            return vmUserTest;
        }

        public VMUserTestDetails Update(VMUpdateUserTestRequest request)
        {
            var userTest = _context.UserTests
               .Where(x => x.UserTestId == request.UserTestId)
               .FirstOrDefault();

            if (userTest == null)
            {
                throw new Exception("User's test could not be found.");
            }

            userTest.UserId = request.UserId;
            userTest.TestId = request.TestId;
            userTest.UserTestStatus = _context.UserTestStatuses
                                    .Where(x => x.UserTestStatusId == request.UserTestStatusId)
                                    .FirstOrDefault();
            userTest.TestSummaryType = _context.TestSummaryTypes
                                    .Where(x => x.TestSummaryTypeId == request.TestSummaryTypeId)
                                    .FirstOrDefault();

            _context.SaveChanges();

            var vmUserTest = new VMUserTestDetails
            {
                TestName = _context.Tests
                   .Where(y => y.TestId == userTest.TestId)
                   .Select(x => x.Name).FirstOrDefault(),
                UserTestId = userTest.UserTestId,
                TestId = userTest.TestId,
                UserId = userTest.UserId,
                UserTestStatusName = _context.UserTestStatuses
                   .Where(y => y.UserTestStatusId == userTest.UserTestStatusId)
                   .Select(x => x.Name).FirstOrDefault(),
                TestSummaryTypeName = _context.TestSummaryTypes
                   .Where(y => y.TestSummaryTypeId == userTest.TestSummaryTypeId)
                   .Select(x => x.Name).FirstOrDefault(),
                TotalPointAquired = userTest.TotalPointAquired,
                TestsCategories = _context.TestCategories
                   .Where(y => y.TestId == userTest.TestId)
                   .Select(z => new VMCategoryTypeItemList
                   {
                       CategoryTypeId = z.CategoryTypeId,
                       Name = z.CategoryType.Name
                   }).ToList(),
                StartDate = userTest.StartDate,
                EndDate = userTest.EndDate
            };

            return vmUserTest;
        }
    }
}