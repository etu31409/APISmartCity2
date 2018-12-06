using System;
using System.Collections.Generic;

namespace APISmartCity.Model
{
    public partial class Horaire
    {
        public int IdHoraire { get; set; }
        public string Libelle { get; set; }
        public DateTime HoraireDebut { get; set; }
        public DateTime HoraireFin { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
