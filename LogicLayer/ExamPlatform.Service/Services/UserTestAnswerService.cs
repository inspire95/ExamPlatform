using ExamPlatform.Database;
using ExamPlatform.Database.Models;
using ExamPlatform.Service.Interfaces;
using ExamPlatform.ViewModels.UserTestAnswer;
using ExamPlatform.ViewModels.UserTestAnswer.Request;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPlatform.Service.Services
{
    public class UserTestAnswerService : IUserTestAnswerService
    {
        private readonly ExamPlatformContext _context;
        public UserTestAnswerService(ExamPlatformContext context)
        {
            _context = context;
        }

		public List<VMUserTestAnswer> GetAll(VMGetUserTestAnswerListRequest request)
		{
			var userTestAnswers = _context.UserTestAnswers.Where(y => y.UserTestId == request.UserTestId)
				.Select(x => new VMUserTestAnswer
				{
					UserTestAnswerId = x.UserTestAnswerId,
					QuestionId = x.QuestionId,
					QuestionContent = x.Question.Content,
					AnswerId = x.AnswerId,
					AnswerContent = x.Answer.Content,
					AnswerPoint = _context.Answers
								.Where(y => y.AnswerId == x.AnswerId)
								.Select(y => y.Points).FirstOrDefault(),
					Content = x.Content
				}).ToList();

			List<VMUserTestAnswer> userTestAnswersWithPoints = new List<VMUserTestAnswer>();

			foreach (var userAnswer in userTestAnswers)
			{
				if (userAnswer.AnswerId == null)
				{
					var userAnswerWithPoints = new VMUserTestAnswer
					{
						UserTestAnswerId = userAnswer.UserTestAnswerId,
						QuestionId = userAnswer.QuestionId,
						AnswerId = userAnswer.AnswerId,
						AnswerContent = userAnswer.AnswerContent,
						Content = userAnswer.Content,
						QuestionContent = userAnswer.QuestionContent,
						AnswerPoint = _context.UserTestAnswers
						.Where(x => x.UserTestAnswerId == userAnswer.UserTestAnswerId)
						.Select(x => x.PointsForOpenQuestion).FirstOrDefault()
					};
					userTestAnswersWithPoints.Add(userAnswerWithPoints);
				}
				else
				{
					userTestAnswersWithPoints.Add(userAnswer);
				}
			}

			return userTestAnswersWithPoints;
		}

		public List<VMUserTestAnswer> GetAllOpenAnswers(VMGetUserTestAnswerListRequest request)
		{
			var userTestAnswers = _context.UserTestAnswers
				.Where(y => y.UserTestId == request.UserTestId && y.AnswerId == null)
				.Select(x => new VMUserTestAnswer
				{
					UserTestAnswerId = x.UserTestAnswerId,
					QuestionId = x.QuestionId,
					Content = x.Content
				}).ToList();

			return userTestAnswers;
		}

		public List<VMUserTestAnswer> GetAllToQuestion(VMGetUserAnswersToQuestionRequest request)
        {
            var userTestAnswers = _context.UserTestAnswers
                .Where(m => m.UserTestId == request.UserTestId && m.QuestionId == request.QuestionId)
                .Select(x => new VMUserTestAnswer
                {
                    UserTestAnswerId = x.UserTestAnswerId,
                    QuestionId = x.QuestionId,
                    AnswerId = x.AnswerId,
                    Content = x.Content
                }).ToList();

            return userTestAnswers;
        }

        public VMUserTestAnswer Create(VMCreateUserTestAnswerRequest vmrequest)
        {
            var newUTAnswer = new DBUserTestAnswer
            {
                Content = vmrequest.Content,
                QuestionId = vmrequest.QuestionId,
                AnswerId = vmrequest.AnswerId,
                UserTestId = vmrequest.UserTestId,
                PointsForOpenQuestion = null
            };
            _context.UserTestAnswers.Add(newUTAnswer);
            _context.SaveChanges();

            var userAnswer = new VMUserTestAnswer
            {
                Content = newUTAnswer.Content,
                AnswerId = newUTAnswer.AnswerId,
                UserTestAnswerId = newUTAnswer.UserTestAnswerId
            };

            return userAnswer;
        }

        public bool RemoveUserAnswersByQuestion(VMRemoveUserTestAnswerRequest vmrequest)
        {
            var userAnswers = _context.UserTestAnswers
                .Where(m => m.UserTestId == vmrequest.UserTestId && m.QuestionId == vmrequest.QuestionId).ToList();

            if (userAnswers != null)
            {
                _context.UserTestAnswers.RemoveRange(userAnswers);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public VMUserTestAnswer VerifyOpenUserQuestion(VMVerifyOpenUserAnswerRequest vmrequest)
        {
            var dbUTAnswer = _context.UserTestAnswers
                 .Where(m => m.UserTestAnswerId == vmrequest.UserTestAnswerId)
                 .FirstOrDefault();

            if (dbUTAnswer == null)
            {
                throw new Exception("Answer could not be found.");
            }

            dbUTAnswer.PointsForOpenQuestion = vmrequest.PointsForOpenQuestion;
            _context.SaveChanges();

            var userAnswer = new VMUserTestAnswer
            {
                Content = dbUTAnswer.Content,
                AnswerId = dbUTAnswer.AnswerId,
                UserTestAnswerId = dbUTAnswer.UserTestAnswerId
            };

            return userAnswer;
        }
    }
}