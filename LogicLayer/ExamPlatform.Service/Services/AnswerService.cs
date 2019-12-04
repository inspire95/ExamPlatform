using ExamPlatform.Database;
using ExamPlatform.Database.Models;
using ExamPlatform.Service.Interfaces;
using ExamPlatform.ViewModels.Answer;
using ExamPlatform.ViewModels.Answer.Request;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPlatform.Service.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly ExamPlatformContext _context;

        public AnswerService(ExamPlatformContext context)
        {
            _context = context;
        }

        public List<VMAnswerListItem> GetAll(VMGetAnswerListRequest vmrequest)
        {
            var answer = _context.Answers
               .Where(x => x.QuestionId == vmrequest.QuestionId)
               .Select(x => new VMAnswerListItem
               {
                   AnswerId = x.AnswerId,
                   Content = x.Content,
                   IsCorrect = x.IsCorrect,
                   Points = x.Points
               }).ToList();

            return answer;
        }

        public VMAnswerDetails Get(VMGetAnswerDetailsRequest vmrequest)
        {
            var answer = _context.Answers
               .Where(x => x.AnswerId == vmrequest.AnswerId)
               .Select(x => new VMAnswerDetails
               {
                   AnswerId = x.AnswerId,
                   Content = x.Content,
                   IsCorrect = x.IsCorrect,
                   Points = x.Points,
                   QuestionId = x.QuestionId

               }).FirstOrDefault();

            if (answer == null)
            {
                throw new Exception("Answer could not be found.");
            }
            else return answer;
        }

        public VMAnswerDetails Create(VMCreateAnswerRequest vmrequest)
        {
            var newMvu = new DBAnswer
            {
                Content = vmrequest.Content,
                Points = vmrequest.Points,
                IsCorrect = vmrequest.IsCorrect,
                QuestionId = vmrequest.QuestionId
            };
            _context.Answers.Add(newMvu);
            _context.SaveChanges();

            var answer = new VMAnswerDetails
            {
                AnswerId = newMvu.AnswerId,
                Content = newMvu.Content,
                IsCorrect = newMvu.IsCorrect,
                Points = newMvu.Points,
                QuestionId = newMvu.QuestionId
            };

            return answer;
        }

        public bool Remove(VMRemoveAnswerRequest vmrequest)
        {
            var answer = _context.Answers
                .Where(x => x.AnswerId == vmrequest.AnswerId)
                .FirstOrDefault();
            if (answer != null)
            {
                _context.Answers.Remove(answer);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public VMAnswerDetails Update(VMUpdateAnswerRequest vmrequest)
        {
            var dbAnswer = _context.Answers
                .Where(m => m.AnswerId == vmrequest.AnswerId)
                .FirstOrDefault();

            if (dbAnswer == null)
            {
                throw new Exception("Answer could not be found.");
            }

            dbAnswer.Content = vmrequest.Content;
            dbAnswer.Points = vmrequest.Points;
            dbAnswer.IsCorrect = vmrequest.IsCorrect;
            dbAnswer.QuestionId = vmrequest.QuestionId;
            _context.SaveChanges();

            var answer = new VMAnswerDetails
            {
                AnswerId = dbAnswer.AnswerId,
                Content = dbAnswer.Content,
                IsCorrect = dbAnswer.IsCorrect,
                Points = dbAnswer.Points,
                QuestionId = dbAnswer.QuestionId
            };
            return answer;
        }
    }
}
