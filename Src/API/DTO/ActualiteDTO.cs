using System;
using System.Collections.Generic;

namespace APISmartCity.DTO
{
    public partial class ActualiteDTO
    {
        public int IdActualite { get; set; }
        public string Libelle { get; set; }
        public string Texte { get; set; }
        public DateTime? Date { get; set; }
        public int? IdCommerce { get; set; }
        public int? IdSiteTouristique { get; set; }
    }
}