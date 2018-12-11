using System;

namespace APISmartCity.Model
{
    public class UserRole
    {
        public string IdRole {get; set;}
        public int IdUser {get; set;}

        public User User {get; set;}

        public Role Role {get; set;}
        public UserRole(){
        }
    }

}