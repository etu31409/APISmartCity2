using System;

namespace APISmartCity.DTO
{
    public class UserRoleDTO
    {
        public string IdRole {get; set;}
        public int IdUser {get; set;}
        public RoleDTO Role {get; set;}

        public UserRoleDTO(){
        }
    }

}