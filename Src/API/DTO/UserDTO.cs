using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APISmartCity.DTO
{
    public class UserDTO
    {
        [Required]
        public string UserName{get; set;}
        [Required]
        public string Password{get;set;}
        [Required]
        [EmailAddress]
        public string Email{get;set;}
        public int Id{get;set;}
        public List<UserRoleDTO> UserRoles { get; set; }

        public UserDTO(){
        }
    }

}