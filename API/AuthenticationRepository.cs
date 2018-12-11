using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using APISmartCity.Model;
using System.Linq;
using System;

namespace APISmartCity.Controllers
{
    public class AuthenticationRepository{
        private  SCNConnectDBContext context;
        public AuthenticationRepository(SCNConnectDBContext context){
            this.context = context;
        }
        
        public IEnumerable<User> GetUsers(){
            return context.User.ToList();
        }
        
    }
}