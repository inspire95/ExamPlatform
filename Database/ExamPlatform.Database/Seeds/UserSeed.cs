using ExamPlatform.Database.Models;
using System;
using System.Linq;

namespace ExamPlatform.Database.Seeds
{
    public static class UserSeed
    {
        public static void DoSeed(ExamPlatformContext context)
        {
            var user1 = new DBUser
            {
                UserId = new Guid("7B6989A2-852F-4E2E-9148-1E7D8B54379F"),
                FirstName = "Lamiusz",
                LastName = "Lama",
                Password = "passsword",
                Email = "eeee@eeee.eeee",
                IsActive = true
            };
            var user2 = new DBUser
            {
                UserId = new Guid("979E8876-9329-4031-9E1E-A956E2C0B6D8"),
                FirstName = "Klaudiusz",
                LastName = "Klama",
                Password = "passsword",
                Email = "eeee@eeee.eeee",
                IsActive = true
            };

            AddOrUpdateUser(user1, context);
            AddOrUpdateUser(user2, context);
        }

        private static void AddOrUpdateUser(DBUser user, ExamPlatformContext context)
        {
            var userToChange = context.Users
                .Where(x => x.UserId == user.UserId)
                .FirstOrDefault();

            if (userToChange == null)
            {
                context.Users.Add(user);
            }
            else
            {
                userToChange.FirstName = user.FirstName;
                userToChange.LastName = user.LastName;
                userToChange.Password = user.Password;
                userToChange.Email = user.Email;
                userToChange.IsActive = user.IsActive;
            }
            context.SaveChanges();
        }
    }
}
