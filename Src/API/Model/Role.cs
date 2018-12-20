using System;
using System.Collections.Generic;

namespace APISmartCity.Model
{
    public class Role
    {
        public string Name {get; set;}
        public List<UserRole> UserRoles { get; set; }
        public Role(){
        }
    }

}