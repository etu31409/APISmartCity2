using System;
using System.Collections.Generic;
namespace APISmartCity.Model
{
    public class User
    {
        public string UserName{get; set;}
        public string Password{get;set;}
        public string Email{get;set;}
        public int Id{get;set;}
        public List<UserRole> UserRoles { get; set; }

        public ICollection<Commerce> Commerce { get; set; }

        public User(){
        }

        // public User(string userName, string email, int id, string password){
        //     this.UserName = userName;
        //     this.Email = email;
        //     this.Id = id;
        //     this.Password = password;
        // }
    }

}