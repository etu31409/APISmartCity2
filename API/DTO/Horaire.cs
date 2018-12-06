using System;
namespace API.DTO
{
    public class Horaire
    {
        public int IdHoraire { get; set; }
        public TimeSpan HeureDebut { get; set; }
        public TimeSpan HeureFin { get; set; }
        public DayOfWeek Jour { get; set; }
        public int CommerceId { get; set; }
        public TimeSpan DureeOuverture { get; set; }
        public byte[] RowVersion { get; set; }

    }
}
    