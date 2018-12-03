using System;
using System.Collections.Generic;

namespace APISmartCity.Model
{
    public partial class Personne
    {
        public int IdPersonne { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public byte? EstCommercant { get; set; }
        public int? NumeroTelephone { get; set; }
        public string MotDePasse { get; set; }
        public int? IdCommerce { get; set; }

        public Commerce IdCommerceNavigation { get; set; }
    }
}
