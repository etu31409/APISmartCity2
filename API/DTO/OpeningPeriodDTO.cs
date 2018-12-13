using System;

namespace APISmartCity.DTO
{
    public class OpeningPeriodDTO
    {
        public int IdHoraire { get; set; }
        public TimeSpan HoraireDebut { get; set; }
        public TimeSpan HoraireFin { get; set; }
        public DayOfWeek Jour { get; set; }
        public int IdCommerce { get; set; }
        public TimeSpan DureeOuverture { get; set; }
        public byte[] RowVersion { get; set; }

    }
}