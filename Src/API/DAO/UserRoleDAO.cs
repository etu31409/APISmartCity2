using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APISmartCity.ExceptionPackage;
using APISmartCity.Model;
using Microsoft.EntityFrameworkCore;
using APISmartCity.DTO;
using AutoMapper;

namespace APISmartCity.DAO
{
    public class UserRoleDAO
    {
        private SCNConnectDBContext context;
        public UserRoleDAO(SCNConnectDBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Model.UserRole> AddUserRole(User user)
        {
            UserRole userRole = new UserRole();
            userRole.IdUser = user.Id;
            userRole.IdRole = Constants.Roles.USER;
            context.Add(userRole);
            await context.SaveChangesAsync();
            return userRole;
        }
    }
}