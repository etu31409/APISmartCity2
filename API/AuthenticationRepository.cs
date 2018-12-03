using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using APISmartCity.Model;
namespace APISmartCity.Controllers
{
    public class AuthenticationRepository{
        private User[] _users = new User[]{
            //TODO Recup les utilisateurs dans la base de données 
            new User(){ UserName="janedoe", Email="jane@doe.com", Id=1, Password="123"},
            new User(){ UserName="johndoe", Email="john@doe.com", Id=2, Password="456"}
        };
        public IEnumerable<User> GetUsers(){
            return _users;
        }
    }
}