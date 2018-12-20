using System;
using System.Collections.Generic;

namespace APISmartCity.Model
{
    public partial class Categorie
    {
        public Categorie()
        {
            Commerce = new HashSet<Commerce>();
        }

        public int IdCategorie { get; set; }
        public string Libelle { get; set; }

        public ICollection<Commerce> Commerce { get; set; }
    }
}
