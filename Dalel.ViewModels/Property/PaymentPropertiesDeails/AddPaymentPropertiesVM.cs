using Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.Property.PaymentPropertiesDeails
{
    public class AddPaymentPropertiesVM
    {
        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, float.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public float Amount { get; set; }   

        [Required(ErrorMessage = "Payment method is required.")]
        public PaymentMethod PaymentMethod { get; set; }

        [Required(ErrorMessage = "Payment status is required.")]
        public PaymentStatus PaymentStatus { get; set; }

        [Required(ErrorMessage = "Transaction date and time is required.")]
        public DateTime TransactionDateTime { get; set; }

        [Required(ErrorMessage = "Amount paid is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount paid must be 0 or more.")]
        public decimal AmountPaid { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Commission must be 0 or more.")]
        public decimal? CommissionDeducted { get; set; }

        public string? CodeApplied { get; set; }

        [Required(ErrorMessage = "BookingPropertyId is required.")]
        public int BookingPropertyId { get; set; }
    }

}
