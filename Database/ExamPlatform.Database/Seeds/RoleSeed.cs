using ExamPlatform.Database.Models;
using ExamPlatform.Globals.Enum;
using System;
using System.Linq;

namespace ExamPlatform.Database.Seeds
{
    public static class RoleSeed
    {
        public static void DoSeed(ExamPlatformContext context)
        {
            foreach (RoleEnum role in Enum.GetValues(typeof(RoleEnum)))
            {
                if ((int)role == 0) continue;
                var dbRole = new DBRole
                {
                    RoleId = (int)role,
                    Name = role.ToString()
                };

                AddOrUpdateRole(dbRole, context);
            }
            DataSeed.ResetSequence(context, "Roles_RoleId_seq", context.Roles.Max(x => x.RoleId) + 1);
        }

        private static void AddOrUpdateRole(DBRole role, ExamPlatformContext context)
        {
            var roleToChange = context.Roles
                .Where(x => x.RoleId == role.RoleId)
                .FirstOrDefault();

            if (roleToChange == null)
            {
                context.Roles.Add(role);
            }
            else
            {
                roleToChange.Name = role.Name;
            }
            context.SaveChanges();
        }
    }
}
