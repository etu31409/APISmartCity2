using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APISmartCity.DTO
{
    public partial class FavorisDTO
    {
        public FavorisDTO(){ }
        [Required]
        public int IdFavoris { get; set; }
        [Required]
        public int IdCommerce { get; set; }
        [Required]
        public int idUser {get; set; }

        // public Commerce IdCommerceNavigation { get; set; }
        // public User IdUserNavigation { get; set; }
    }
}
