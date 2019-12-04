using ExamPlatform.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ExamPlatform.Database
{
    public class ExamPlatformContext : DbContext
    {
        public ExamPlatformContext(DbContextOptions options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile("connectionStrings.json", optional: true, reloadOnChange: true)
                    .Build();

                var connectionString = configuration.GetConnectionString("ExamPlatformContext");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			FluentApiTablesDefinition.Register(ref modelBuilder);
			FluentApiTablesRelation.Register(ref modelBuilder);
            
            base.OnModelCreating(modelBuilder);
        }
        
        public virtual DbSet<DBAnswer> Answers { get; set; }
		public virtual DbSet<DBAttachment> Attachments { get; set; }
		public virtual DbSet<DBAttachmentType> AttachementTypes { get; set; }
		public virtual DbSet<DBCategoryType> CategoryTypes { get; set; }
        public virtual DbSet<DBQuestion> Questions { get; set; }
        public virtual DbSet<DBQuestionCategory> QuestionCategories { get; set; }
        public virtual DbSet<DBQuestionType> QuestionTypes { get; set; }
        public virtual DbSet<DBRole> Roles { get; set; }
		public virtual DbSet<DBTest> Tests { get; set; }
		public virtual DbSet<DBTestCategory> TestCategories { get; set; }
		public virtual DbSet<DBTestQuestion> TestQuestions { get; set; }
		public virtual DbSet<DBTestSummaryType> TestSummaryTypes { get; set; }
		public virtual DbSet<DBUser> Users { get; set; }
		public virtual DbSet<DBUserRole> UserRoles { get; set; }
		public virtual DbSet<DBUserTest> UserTests { get; set; }
		public virtual DbSet<DBUserTestStatus> UserTestStatuses { get; set; }
        public virtual DbSet<DBUserTestAnswer> UserTestAnswers { get; set; }
    }
}
