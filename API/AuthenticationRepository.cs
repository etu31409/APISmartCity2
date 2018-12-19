using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using APISmartCity.Model;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace APISmartCity.Controllers
{
    public class AuthenticationRepository{
        private  SCNConnectDBContext context;
        public AuthenticationRepository(SCNConnectDBContext context){
            this.context = context;
        }
        
        public IEnumerable<User> GetUsers(){
            return context.User
            .Include(user => user.UserRoles)
            .ThenInclude(r => r.Role)
            .ToList();
        }
        
    }
}