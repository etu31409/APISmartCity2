using System;
using System.ComponentModel.DataAnnotations;

namespace APISmartCity.DTO
{
    public class OpeningPeriodDTO
    {
        
        public int IdHoraire { get; set; }
        [Required]
        public TimeSpan HoraireDebut { get; set; }
        [Required]
        public TimeSpan HoraireFin { get; set; }
        [Required]
        public DayOfWeek Jour { get; set; }
        public int IdCommerce { get; set; }
        public TimeSpan DureeOuverture { get; set; }
        public byte[] RowVersion { get; set; }

    }
}