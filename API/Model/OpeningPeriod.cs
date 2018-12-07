using System;
using System.Collections.Generic;
using APISmartCity.ExceptionPackage;

namespace APISmartCity.Model
{
    public class OpeningPeriod
    {
        public int IdHoraire { get; set; }
        public TimeSpan HoraireDebut { get; set; }
        public TimeSpan HoraireFin { get; set; }
        public DayOfWeek Jour { get; set; }
        public int? IdCommerce { get; set; }
        public byte[] RowVersion { get; set; }

        public Commerce IdCommerceNavigation { get; set; }

        private OpeningPeriod(){
            //Nécessaire pour EF Core
        }
        public OpeningPeriod(TimeSpan opening, TimeSpan closing, DayOfWeek day)
        {
            if(opening >= closing)
                throw new InvalidOpeningPeriodException();
            HoraireDebut = opening;
            HoraireFin = closing;
            Jour = day;
        }
    }
}
