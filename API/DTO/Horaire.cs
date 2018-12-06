using System;
namespace API.DTO
{
    public class Horaire
    {
        public int Id { get; set; }
        public TimeSpan Opening { get; set; }
        public TimeSpan Closing { get; set; }
        public DayOfWeek Day { get; set; }
        public int ShopId { get; set; }
        public TimeSpan DurationOfOpening { get; set; }
        public byte[] RowVersion { get; set; }

    }
}
    