using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DBFirst.DTO
{
    public class ReservationDTO
    {
        public int id { get; set; }
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
        public System.DateTime CheckInDate { get; set; }
        public System.DateTime CheckOutDate { get; set; }


        public string RoomType { get; set; }
        public string RoomNumber { get; set; }
        public int PricePerNight { get; set; }


        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
