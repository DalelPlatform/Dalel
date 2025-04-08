using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.Hotel_DTO
{
    public class PaymentHotelRoomDTO
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal? CommissionDeducted { get; set; }
        public string CodeApplied { get; set; }
        public string PaymentMethod { get; set; } // Enum mapped to string
        public string PaymentStatus { get; set; } // Enum mapped to string
        public DateTime TransactionDateTime { get; set; }
    }

}
