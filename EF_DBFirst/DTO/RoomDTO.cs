using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DBFirst.DTO
{
    public class RoomDTO
    {
        public int id { get; set; }
        public int HotelId { get; set; }
        public string RoomNumber { get; set; }
        public string Type { get; set; }
        public int PricePerNight { get; set; }
        public bool Availability { get; set; }

        public virtual List<Reservation> Reservation { get; set; }
    }
}
