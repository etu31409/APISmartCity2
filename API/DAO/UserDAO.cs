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
                throw new CommerceNotFoundException();
            context.User.Add(user);
            await context.SaveChangesAsync();
            return user;
        }
    }
}