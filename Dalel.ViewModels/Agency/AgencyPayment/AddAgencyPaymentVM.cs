using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enums;

namespace Dalel.ViewModels.Agency.PackageBookingPayment
{
    public class AddAgencyPaymentVM
    {
        [Required(ErrorMessage = "Please Provide Amount")]

        public decimal Amount { get; set; }
        [Required(ErrorMessage = "Please Provide AmountPaid")]
        public decimal AmountPaid { get; set; }
        [Required(ErrorMessage = "Please Provide CommissionDeducted")]
        public decimal? CommissionDeducted { get; set; }
        [Required(ErrorMessage = "Please Provide CodeApplied")]
        public string? CodeApplied { get; set; }
        [Required(ErrorMessage = "Please Provide Date")]
        public DateTime Date { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public int BookingId { get; set; }

    }
}
