using ExamPlatform.Database;
using ExamPlatform.Service.Interfaces;
using ExamPlatform.ViewModels.QuestionType;
using ExamPlatform.ViewModels.QuestionType.Request;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPlatform.Service.Services
{
    public class QuestionTypeService : IQuestionTypeService
    {
        private readonly ExamPlatformContext _context;

        public QuestionTypeService(ExamPlatformContext context)
        {
            _context = context;
        }

        public List<VMQuestionType> GetAll(VMGetQuestionTypeListRequest vmrequest)
        {
            var types = _context.QuestionTypes
                .Select(x => new VMQuestionType
                {
                    QuestionTypeId = x.QuestionTypeId,
                    Name = x.Name
                }).ToList();

            return types;
        }

        public VMQuestionType Get(VMGetQuestionTypeRequest vmrequest)
        {
            var dbQuestionType = _context.QuestionTypes
               .Where(m => m.QuestionTypeId == vmrequest.QuestionTypeId)
               .FirstOrDefault();

            if (dbQuestionType == null)
            {
                throw new Exception("Question type could not be found.");
            }

            var questionType = new VMQuestionType
            {
                QuestionTypeId = dbQuestionType.QuestionTypeId,
                Name = dbQuestionType.Name
            };

            return questionType;
        }        
    }
}
