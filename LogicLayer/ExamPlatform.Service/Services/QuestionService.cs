using ExamPlatform.Database;
using ExamPlatform.Database.Models;
using ExamPlatform.Service.Interfaces;
using ExamPlatform.ViewModels.Question;
using ExamPlatform.ViewModels.Question.Request;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPlatform.Service.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly ExamPlatformContext _context;
        private readonly CategoryTypeService _categoryTypeService;

        public QuestionService(ExamPlatformContext context, CategoryTypeService categoryTypeService)
        {
            _context = context;
            _categoryTypeService = categoryTypeService;
        }

        public List<VMQuestion> GetAll(VMGetQuestionListRequest request)
        {
            var questions = _context.Questions.Where(x => x.IsActive == true)
                .Select(x => new VMQuestion
                {
                    QuestionId = x.QuestionId,
                    Content = x.Content,
                    PointsSum = x.PointsSum,
                    QuestionTypeId = x.QuestionType.QuestionTypeId,
                    CategoryTypeIds = x.QuestionsCategories.Select(y => y.CategoryTypeId).ToList()
                }).ToList();

            return questions;
        }

        public VMQuestion Get(VMGetQuestionDetailsRequest request)
        {
            var question = _context.Questions
               .Where(x => x.QuestionId == request.QuestionId)
               .Select(x => new VMQuestion
               {
                   QuestionId = x.QuestionId,
                   IsActive = x.IsActive,
                   Content = x.Content,
                   PointsSum = x.PointsSum,
                   QuestionTypeId = x.QuestionType.QuestionTypeId,
                   CategoryTypeIds = x.QuestionsCategories.Select(y => y.CategoryTypeId).ToList()
               }).FirstOrDefault();

            if (question == null)
            {
                throw new Exception("Not found");
            }
            else return question;
        }

        public VMQuestion Create(VMCreateQuestionRequest request)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var newQuestion = new DBQuestion
                    {
                        Content = request.Content,
                        PointsSum = request.PointsSum,
                        IsActive = true,
                        QuestionTypeId = request.QuestionTypeId
                    };
                    _context.Questions.Add(newQuestion);
                    _context.SaveChanges();
                    _categoryTypeService.AssignCategoryToQuestion(newQuestion.QuestionId, request.CategoryTypeIds);

                    VMQuestion vmQuestion = new VMQuestion
                    {
                        QuestionId = newQuestion.QuestionId,
                        IsActive = newQuestion.IsActive,
                        Content = newQuestion.Content,
                        PointsSum = newQuestion.PointsSum,
                        QuestionTypeId = newQuestion.QuestionTypeId,
                        CategoryTypeIds = newQuestion.QuestionsCategories.Select(y => y.CategoryTypeId).ToList()
                    };

                    transaction.Commit();
                    return vmQuestion;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public bool Remove(VMRemoveQuestionRequest request)
        {
            var question = _context.Questions
                .Where(m => m.QuestionId == request.QuestionId)
                .FirstOrDefault();

            if (question == null)
            {
                return false;
            }

            question.IsActive = false;
            _context.SaveChanges();
            return true;
        }

        public VMQuestion Update(VMUpdateQuestionRequest request)
        {
            var question = _context.Questions
                .Where(m => m.QuestionId == request.QuestionId)
                .FirstOrDefault();

            if (question == null)
            {
                throw new Exception("Question could not be found.");
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    question.QuestionId = request.QuestionId;
                    question.Content = request.Content;
                    question.PointsSum = request.PointsSum;
                    question.QuestionTypeId = request.QuestionTypeId;
                    _context.SaveChanges();
                    _categoryTypeService.AssignCategoryToQuestion(question.QuestionId, request.CategoryTypeIds);

                    var vmQuestion = new VMQuestion
                    {
                        QuestionId = question.QuestionId,
                        IsActive = question.IsActive,
                        Content = question.Content,
                        PointsSum = question.PointsSum,
                        QuestionTypeId = question.QuestionTypeId,
                        CategoryTypeIds = question.QuestionsCategories.Select(y => y.CategoryTypeId).ToList()
                    };

                    transaction.Commit();
                    return vmQuestion;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public bool AssignQuestionToTest(int testId, ICollection<int> questionIdList)
        {
            var toClear = _context.TestQuestions.Where(x => x.TestId == testId).ToList();
            if (toClear != null)
            {
                foreach (var item in toClear)
                {
                    _context.TestQuestions.Remove(item);
                }
            }
            if (questionIdList != null)
            {
                foreach (int questionId in questionIdList)
                {
                    var tq = new DBTestQuestion
                    {
                        TestId = testId,
                        QuestionId = questionId
                    };
                    _context.TestQuestions.Add(tq);
                }
            }
            _context.SaveChanges();
            return true;
        }

        public List<VMQuestion> DrawOpenQuestions(int howMany, int categoryTypeId)
        {
            var questionsIds = _context.QuestionCategories
                .Where(x => x.CategoryTypeId == categoryTypeId)
                .Select(x => x.QuestionId).ToList();

            var openQuestion = _context.Questions
                .Where(x => x.IsActive == true && x.QuestionTypeId == 3 && questionsIds.Contains(x.QuestionId))
                .Select(x => new VMQuestion
                {
                    IsActive = x.IsActive,
                    QuestionId = x.QuestionId,
                    Content = x.Content,
                    PointsSum = x.PointsSum,
                    QuestionTypeId = x.QuestionType.QuestionTypeId,
                    CategoryTypeIds = x.QuestionsCategories.Select(y => y.CategoryTypeId).ToList()
                }).ToList();

            Random rand = new Random();

            var questionOpen = new List<VMQuestion>();
            if (howMany >= openQuestion.Count)
            {
                howMany = openQuestion.Count;
            }
            for (int i = 0; i < howMany; i++)
            {
                int r = rand.Next(openQuestion.Count);
                var question = openQuestion[r];
                openQuestion.RemoveAt(r);
                questionOpen.Add(question);
            }
            return questionOpen;
        }
        public List<VMQuestion> DrawClosedQuestions(int howMany, int categoryTypeId)
        {
            var questionsIds = _context.QuestionCategories
                .Where(x => x.CategoryTypeId == categoryTypeId)
                .Select(x => x.QuestionId).ToList();

            var closedQuestion = _context.Questions
                .Where(x => x.IsActive == true && x.QuestionTypeId == 1 || x.QuestionTypeId == 2 && questionsIds.Contains(x.QuestionId))
                .Select(x => new VMQuestion
                {
                    IsActive = x.IsActive,
                    QuestionId = x.QuestionId,
                    Content = x.Content,
                    PointsSum = x.PointsSum,
                    QuestionTypeId = x.QuestionType.QuestionTypeId,
                    CategoryTypeIds = x.QuestionsCategories.Select(y => y.CategoryTypeId).ToList()
                }).ToList();

            Random rand = new Random();

            var questionClosed = new List<VMQuestion>();
            if (howMany >= closedQuestion.Count)
            {
                howMany = closedQuestion.Count;
            }
            for (int i = 0; i < howMany; i++)
            {
                int r = rand.Next(closedQuestion.Count);
                var question = closedQuestion[r];
                closedQuestion.RemoveAt(r);
                questionClosed.Add(question);
            }
            return questionClosed;
        }
    }
}