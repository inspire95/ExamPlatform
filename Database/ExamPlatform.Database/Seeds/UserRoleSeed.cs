using ExamPlatform.Database.Models;
using System;
using System.Linq;

namespace ExamPlatform.Database.Seeds
{
    public static class UserRoleSeed
    {
        public static void DoSeed(ExamPlatformContext context)
        {
            var userRole1 = new DBUserRole
            {
                UserId = new Guid("7B6989A2-852F-4E2E-9148-1E7D8B54379F"),
                RoleId = 2
            };
            var userRole2 = new DBUserRole
            {
                UserId = new Guid("979E8876-9329-4031-9E1E-A956E2C0B6D8"),
                RoleId = 1
            };

            AddUserRole(userRole1, context);
            AddUserRole(userRole2, context);
        }

        private static void AddUserRole(DBUserRole userRole, ExamPlatformContext context)
        {
            var userRoleToChange = context.UserRoles
                .Where(x => x.RoleId == userRole.RoleId && x.UserId == userRole.UserId)
                .FirstOrDefault();

            if (userRoleToChange == null)
            {
                context.UserRoles.Add(userRole);
                context.SaveChanges();
            }
        }
    }
}
