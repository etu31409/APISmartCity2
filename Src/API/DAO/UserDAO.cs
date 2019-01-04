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
    public class UserDAO
    {
        private SCNConnectDBContext context;
        
        public UserDAO(SCNConnectDBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Model.User> AddUser(User user)
        {
            if (user == null)
                throw new UserNotFoundException();
            context.User.Add(user);
            UserRole userRole= new UserRole();
            UserRoleDAO userRoleDAO = new UserRoleDAO(context);
            await context.SaveChangesAsync();
            await userRoleDAO.AddUserRole(user);
            return user;
        }

        public async Task<Model.User> GetUser(string email)
        {
            return await context.User
            .FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task<User> GetUserWithId(int id)
        {
            return await context.User
                .Include(user => user.UserRoles)
                .ThenInclude(r => r.Role)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}