using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DBFirst.DTO
{
    public class PaymentDTO
    {
        public int id { get; set; }
        public int TotalPrice { get; set; }
        public System.DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
    }
}
