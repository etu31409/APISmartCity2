using System;
using System.Collections.Generic;

namespace APISmartCity.Model
{
    public partial class Promotion
    {
        public int IdPromotion { get; set; }
        public string Libelle { get; set; }
        public int? Pourcentage { get; set; }
        public DateTime DateDeb { get; set; }
        public DateTime? DateFin { get; set; }
        public string Conditions { get; set; }
    }
}
