using System;
using System.Collections.Generic;

namespace APISmartCity.Model
{
    public partial class FavorisDTO
    {
       

        public FavorisDTO()
        {
            
        }

        public int IdFavoris { get; set; }
        public int IdCommerce { get; set; }
        public int idUser {get; set; }

        public Commerce IdCommerceNavigation { get; set; }
        public User IdUserNavigation { get; set; }
    }
}
