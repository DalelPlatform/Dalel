using Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class AddPaymentVehicle
    {
        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, float.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Amount paid is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount paid must be 0 or more.")]
        public decimal AmountPaid { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Commission must be 0 or more.")]

        public decimal? CommissionDeducted { get; set; }

        [Required(ErrorMessage = "Payment method is required.")]
        public PaymentMethod PaymentMethod { get; set; } // e.g. cash, PayPal, Stripe
        [Required(ErrorMessage = "Payment status is required.")]
        public PaymentStatus PaymentStatus { get; set; } // e.g. pending, completed
        public DateTime TransactionDateTime { get; set; }
        public int BookingVehicleId { get; set; }
    }

}
