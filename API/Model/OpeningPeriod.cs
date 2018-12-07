using System;
using System.Collections.Generic;

namespace APISmartCity.Model
{
    public partial class OpeningPeriod
    {
        public int IdHoraire { get; set; }
        public TimeSpan HoraireDebut { get; set; }
        public TimeSpan HoraireFin { get; set; }
        public int Jour { get; set; }
        public int? IdCommerce { get; set; }
        public byte[] RowVersion { get; set; }

        public Commerce IdCommerceNavigation { get; set; }
    }
}
