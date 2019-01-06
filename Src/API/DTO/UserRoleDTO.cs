using System;
using System.ComponentModel.DataAnnotations;

namespace APISmartCity.DTO
{
    public class UserRoleDTO
    {
        [Required]
        public string IdRole {get; set;}
        [Required]
        public int IdUser {get; set;}
        [Required]
        public RoleDTO Role {get; set;}

        public UserRoleDTO(){
        }
    }

}