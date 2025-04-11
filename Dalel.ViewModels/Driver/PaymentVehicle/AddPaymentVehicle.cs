using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.Driver.PaymentVehicle
{
    public class AddPaymentVehicle
    {
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public int BookingVehicleId { get; set; }
    }

}
