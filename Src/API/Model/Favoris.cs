using System;
using System.Collections.Generic;

namespace APISmartCity.Model
{
    public partial class Favoris
    {
       

        public Favoris()
        {
            
        }

        public int IdFavoris { get; set; }
        public int IdCommerce { get; set; }
        public int IdUser {get; set; }

        public Commerce IdCommerceNavigation { get; set; }
        public User IdUserNavigation { get; set; }
    }
}
