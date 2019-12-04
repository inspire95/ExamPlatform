using ExamPlatform.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamPlatform.Database
{
    class FluentApiTablesRelation
    {
        public static void Register(ref ModelBuilder modelBuilder)
        {
            //Question(ONE) to Attachment(ONE)
            modelBuilder.Entity<DBQuestion>()
                 .HasOne<DBAttachment>(a => a.Attachment)
                 .WithOne(aq => aq.Question)
                 .HasForeignKey<DBAttachment>(aq => aq.AttachmentId);

            //Answer(MANY) to Question(ONE)
            modelBuilder.Entity<DBAnswer>()
                 .HasOne<DBQuestion>(q => q.Question)
                 .WithMany(sq => sq.Anwsers)
                 .HasForeignKey(sq => sq.QuestionId);

            //Attachment(MANY) to AttachmentType(ONE)
            modelBuilder.Entity<DBAttachment>()
                 .HasOne<DBAttachmentType>(a => a.AttachmentType)
                 .WithMany(at => at.Attachments)
                 .HasForeignKey(at => at.AttachmentTypeId);

            //Question(MANY) to QuestionType(ONE)
            modelBuilder.Entity<DBQuestion>()
                 .HasOne<DBQuestionType>(q => q.QuestionType)
                 .WithMany(qt => qt.Questions)
                 .HasForeignKey(qt => qt.QuestionTypeId);

            //UserTest(MANY) to UserTestStatus(ONE)
            modelBuilder.Entity<DBUserTest>()
                 .HasOne<DBUserTestStatus>(u => u.UserTestStatus)
                 .WithMany(us => us.UsersTests)
                 .HasForeignKey(us => us.UserTestStatusId);

            //UserTest(MANY) to TestSummaryType(ONE)
            modelBuilder.Entity<DBUserTest>()
                 .HasOne<DBTestSummaryType>(t => t.TestSummaryType)
                 .WithMany(ts => ts.UsersTests)
                 .HasForeignKey(ts => ts.TestSummaryTypeId);

            ///UserTest(MANY) to UserTestAnswers(ONE)
            modelBuilder.Entity<DBUserTestAnswer>()
                 .HasOne<DBUserTest>(t => t.UserTest)
                 .WithMany(ts => ts.UserTestAnswers)
                 .HasForeignKey(ts => ts.UserTestId);

            ///Answer(MANY) to UserTestAnswers(ONE)
            modelBuilder.Entity<DBUserTestAnswer>()
                 .HasOne<DBAnswer>(t => t.Answer)
                 .WithMany(ts => ts.UserTestAnswers)
                 .HasForeignKey(ts => ts.AnswerId);

            ///Question(MANY) to UserTestAnswers(ONE)
            modelBuilder.Entity<DBUserTestAnswer>()
                 .HasOne<DBQuestion>(t => t.Question)
                 .WithMany(ts => ts.UserTestAnswers)
                 .HasForeignKey(ts => ts.QuestionId);

            //Test(MANY) to CategoryType(MANY) ==> TestCategory
            modelBuilder.Entity<DBTestCategory>()
                 .HasOne<DBCategoryType>(c => c.CategoryType)
                 .WithMany(ct => ct.TestsCategories)
                 .HasForeignKey(ct => ct.CategoryTypeId);

            modelBuilder.Entity<DBTestCategory>()
                 .HasOne<DBTest>(t => t.Test )
                 .WithMany(tc => tc.TestsCategories)
                 .HasForeignKey(tc => tc.TestId);

			//Question(MANY) to CategoryType(MANY) ==> QuestionCategory
			modelBuilder.Entity<DBQuestionCategory>()
				 .HasOne<DBCategoryType>(c => c.CategoryType)
				 .WithMany(cq => cq.QuestionsCategories)
				 .HasForeignKey(cq => cq.CategoryTypeId);
			
			modelBuilder.Entity<DBQuestionCategory>()
				 .HasOne<DBQuestion>(q => q.Question)
				 .WithMany(qc => qc.QuestionsCategories)
				 .HasForeignKey(qc => qc.QuestionId);				 

            //User(MANY) to Role(MANY) ==> UserRole
            modelBuilder.Entity<DBUserRole>()
                .HasOne<DBRole>(c => c.Role)
                .WithMany(cq => cq.UsersRoles)
                .HasForeignKey(cq => cq.RoleId);

            modelBuilder.Entity<DBUserRole>()
                 .HasOne<DBUser>(q => q.User)
                 .WithMany(qc => qc.UsersRoles)
                 .HasForeignKey(qc => qc.UserId);

            //User(MANY) to Test(MANY) ==> UserTest
            modelBuilder.Entity<DBUserTest>()
                .HasOne<DBTest>(t => t.Test)
                .WithMany(tu => tu.UsersTests)
                .HasForeignKey(tu => tu.TestId);

            modelBuilder.Entity<DBUserTest>()
                .HasOne<DBUser>(u => u.User)
                .WithMany(ut => ut.UsersTests)
                .HasForeignKey(ut => ut.UserId);

            //Test(MANY) to Question(MANY) ==> TestQuestion
            modelBuilder.Entity<DBTestQuestion>()
                .HasOne<DBQuestion>(q => q.Question)
                .WithMany(qt => qt.TestsQuestions)
                .HasForeignKey(qt => qt.QuestionId);

            modelBuilder.Entity<DBTestQuestion>()
                .HasOne<DBTest>(t => t.Test)
                .WithMany(tq => tq.TestsQuestions)
                .HasForeignKey(tq => tq.TestId);
        }
    }
}
