using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APISmartCity.DTO
{
    public class RoleDTO
    {
        [Required]
        public string Name {get; set;}
        public RoleDTO(){
        }
    }

}