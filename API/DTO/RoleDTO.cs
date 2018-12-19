using System;
using System.Collections.Generic;

namespace APISmartCity.DTO
{
    public class RoleDTO
    {
        public string Name {get; set;}
        public RoleDTO(){
        }

        public override string ToString()
        {
            return Name;
        }
    }

}