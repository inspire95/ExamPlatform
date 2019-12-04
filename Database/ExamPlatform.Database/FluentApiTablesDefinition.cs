using ExamPlatform.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamPlatform.Database
{
    public static class FluentApiTablesDefinition
    {
        private const int MaxLengthForTexts = 200;
        private const int MaxLengthForNames = 30;

        public static void Register(ref ModelBuilder modelBuilder)
        {
            //Answers
            modelBuilder.Entity<DBAnswer>().ToTable("Answers");
            modelBuilder.Entity<DBAnswer>().HasKey(x => x.AnswerId);
            modelBuilder.Entity<DBAnswer>(eb =>
            {
                eb.Property(x => x.AnswerId).ValueGeneratedOnAdd();
                eb.Property(x => x.Content).HasMaxLength(MaxLengthForTexts);
            });

            //Attachments
            modelBuilder.Entity<DBAttachment>().ToTable("Attachments");
            modelBuilder.Entity<DBAttachment>().HasKey(x => x.AttachmentId);
            modelBuilder.Entity<DBAttachment>(eb =>
            {
                eb.Property(x => x.AttachmentId).ValueGeneratedOnAdd();
                eb.Property(x => x.Text).HasMaxLength(MaxLengthForTexts);
                eb.Property(x => x.FilePath).IsRequired();
            });

            //AttachmentTypes
            modelBuilder.Entity<DBAttachmentType>().ToTable("AttachmentTypes");
            modelBuilder.Entity<DBAttachmentType>().HasKey(x => x.AttachmentTypeId);
            modelBuilder.Entity<DBAttachmentType>(eb =>
            {
                eb.Property(x => x.AttachmentTypeId).ValueGeneratedOnAdd();
                eb.Property(x => x.Name).IsRequired().HasMaxLength(MaxLengthForNames);
            });

            //CategoryTypes
            modelBuilder.Entity<DBCategoryType>().ToTable("CategoryTypes");
            modelBuilder.Entity<DBCategoryType>().HasKey(x => x.CategoryTypeId);
            modelBuilder.Entity<DBCategoryType>(eb =>
            {
                eb.Property(x => x.CategoryTypeId).ValueGeneratedOnAdd();
                eb.Property(x => x.Name).IsRequired().HasMaxLength(MaxLengthForNames);
            });

            //Roles
            modelBuilder.Entity<DBRole>().ToTable("Roles");
            modelBuilder.Entity<DBRole>().HasKey(x => x.RoleId);
            modelBuilder.Entity<DBRole>(eb =>
            {
                eb.Property(x => x.RoleId).ValueGeneratedOnAdd();
                eb.Property(x => x.Name).IsRequired().HasMaxLength(MaxLengthForNames);
            });

            //Tests
            modelBuilder.Entity<DBTest>().ToTable("Tests");
            modelBuilder.Entity<DBTest>().HasKey(x => new { x.TestId });
            modelBuilder.Entity<DBTest>(eb =>
            {
                eb.Property(x => x.TestId).ValueGeneratedOnAdd();
                eb.Property(x => x.Name).IsRequired().HasMaxLength(MaxLengthForNames);
            });

            //TestSummaryType
            modelBuilder.Entity<DBTestSummaryType>().ToTable("TestSummaryTypes");
            modelBuilder.Entity<DBTestSummaryType>().HasKey(x => new { x.TestSummaryTypeId });
            modelBuilder.Entity<DBTestSummaryType>(eb =>
            {
                eb.Property(x => x.TestSummaryTypeId).ValueGeneratedOnAdd();
                eb.Property(x => x.Name).IsRequired().HasMaxLength(MaxLengthForNames);
            });

            //UsersTests
            modelBuilder.Entity<DBUserTest>().ToTable("UsersTests");
            modelBuilder.Entity<DBUserTest>().HasKey(x => x.UserTestId);
            modelBuilder.Entity<DBUserTest>(eb =>
            {
                eb.Property(x => x.UserTestId).ValueGeneratedOnAdd();
                eb.Property(x => x.StartDate).HasColumnType("timestamp");
            });

            //UserTestStatuses
            modelBuilder.Entity<DBUserTestStatus>().ToTable("UserTestStatuses");
            modelBuilder.Entity<DBUserTestStatus>().HasKey(x => new { x.UserTestStatusId });
            modelBuilder.Entity<DBUserTestStatus>(eb =>
            {
                eb.Property(x => x.UserTestStatusId).ValueGeneratedOnAdd();
                eb.Property(x => x.Name).IsRequired().HasMaxLength(MaxLengthForNames);
            });

            //Users
            modelBuilder.Entity<DBUser>().ToTable("Users");
            modelBuilder.Entity<DBUser>().HasKey(x => x.UserId);
            modelBuilder.Entity<DBUser>(eb =>
            {
                eb.Property(x => x.UserId).ValueGeneratedOnAdd();
                eb.Property(x => x.Email).IsRequired().HasMaxLength(MaxLengthForNames);
                eb.Property(x => x.Password).IsRequired().HasMaxLength(16);
            });

            //UserTestAnswers
            modelBuilder.Entity<DBUserTestAnswer>().ToTable("UserTestAnswer");
            modelBuilder.Entity<DBUserTestAnswer>().HasKey(x => x.UserTestAnswerId);
            modelBuilder.Entity<DBUserTestAnswer>(eb =>
            {
                eb.Property(x => x.UserTestAnswerId).ValueGeneratedOnAdd();
            });

            //QuestionTypes
            modelBuilder.Entity<DBQuestionType>().ToTable("QuestionTypes");
            modelBuilder.Entity<DBQuestionType>().HasKey(x => new { x.QuestionTypeId });
            modelBuilder.Entity<DBQuestionType>(eb =>
            {
                eb.Property(x => x.QuestionTypeId).ValueGeneratedOnAdd();
                eb.Property(x => x.Name).IsRequired().HasMaxLength(MaxLengthForNames);
            });

            //Questions
            modelBuilder.Entity<DBQuestion>().ToTable("Questions");
            modelBuilder.Entity<DBQuestion>().HasKey(x => x.QuestionId);
            modelBuilder.Entity<DBQuestion>(eb =>
            {
                eb.Property(x => x.QuestionId).ValueGeneratedOnAdd();
                eb.Property(x => x.Content).HasMaxLength(MaxLengthForTexts);
            });

            //Support tables
            modelBuilder.Entity<DBUserRole>().ToTable("UsersRoles");
            modelBuilder.Entity<DBUserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<DBQuestionCategory>().ToTable("QuestionsCategories");
            modelBuilder.Entity<DBQuestionCategory>().HasKey(x => new { x.QuestionId, x.CategoryTypeId });

            modelBuilder.Entity<DBTestQuestion>().ToTable("TestsQuestions");
            modelBuilder.Entity<DBTestQuestion>().HasKey(x => new { x.TestId, x.QuestionId });

            modelBuilder.Entity<DBTestCategory>().ToTable("TestsCategories");
            modelBuilder.Entity<DBTestCategory>().HasKey(x => new { x.TestId, x.CategoryTypeId });
        }
    }
}

