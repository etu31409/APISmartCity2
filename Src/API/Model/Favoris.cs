using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISmartCity.Model
{
    public partial class Favoris
    {
       

        public Favoris()
        {
            
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdFavoris { get; set; }
        public int IdCommerce { get; set; }
        public int IdUser {get; set; }

        public Commerce IdCommerceNavigation { get; set; }
        public User IdUserNavigation { get; set; }
    }
}
