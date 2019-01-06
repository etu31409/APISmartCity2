using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APISmartCity.DTO
{
    public partial class ActualiteDTO
    {
        [Required]
        public int IdActualite { get; set; }
        [Required]
        public string Libelle { get; set; }
        [Required]
        public string Texte { get; set; }
        public DateTime? Date { get; set; }
        public int? IdCommerce { get; set; }
        public int? IdSiteTouristique { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
