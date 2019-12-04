using ExamPlatform.Database;
using ExamPlatform.Service.Interfaces;
using System;

namespace ExamPlatform.Service.Services
{
    public class SeedService : ISeedService
    {
        private readonly ExamPlatformContext _context;

        public SeedService(ExamPlatformContext context)
        {
            _context = context;
        }

        public bool Seed()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    DataSeed.DoSeed(_context);
                    return true;
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
