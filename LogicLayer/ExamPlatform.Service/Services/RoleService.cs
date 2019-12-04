using ExamPlatform.Database;
using ExamPlatform.Database.Models;
using ExamPlatform.ViewModels.Role;
using ExamPlatform.ViewModels.Role.Request;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPlatform.Service.Services
{
    public class RoleService : IRoleService
    {
        private readonly ExamPlatformContext _context;
        public RoleService(ExamPlatformContext context)
        {
            _context = context;
        }

        public List<VMRole> GetAll(VMGetRoleListRequest request)
        {
            var roles = _context.Roles
                .Select(x => new VMRole
                {
                    Name = x.Name
                }).ToList();

            return roles;
        }

        public VMRole Get(VMGetRoleRequest request)
        {
            var role = _context.Roles
                .Where(m => m.RoleId == request.RoleId)
                .FirstOrDefault();

            if (role == null)
            {
                throw new Exception("Role could not be found.");
            }

            var vmRole = new VMRole
            {
                Name = role.Name
            };

            return vmRole;
        }

        public bool AssignRoleToUser(Guid userId, ICollection<int> roleIdList)
        {
            var toClear = _context.UserRoles.Where(x => x.UserId == userId).ToList();
            if (toClear != null)
            {
                foreach (var item in toClear)
                {
                    _context.UserRoles.Remove(item);
                }
            }
            if (roleIdList != null)
            {
                foreach (int roleId in roleIdList)
                {
                    var ur = new DBUserRole
                    {
                        UserId = userId,
                        RoleId = roleId
                    };
                    _context.UserRoles.Add(ur);
                }
            }
            _context.SaveChanges();
            return true;
        }
    }
}

