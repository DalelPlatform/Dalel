using System;
using System.ComponentModel.DataAnnotations;
using Models.Enums;

namespace Dalel.ViewModels
{
    public class AddPaymentHomeChefOrderVM
    {
        [Range(0.01, 100000, ErrorMessage = "Amount must be between 0.01 and 100,000.")]
        public float Amount { get; set; }

        [Range(0.01, 100000, ErrorMessage = "Amount Paid must be between 0.01 and 100,000.")]
        public decimal AmountPaid { get; set; }

        [Range(0, 100000, ErrorMessage = "Commission Deducted must be between 0 and 100,000.")]
        public decimal? CommissionDeducted { get; set; }

        [StringLength(50, ErrorMessage = "Code Applied can't be longer than 50 characters.")]
        public string? CodeApplied { get; set; }

        [Required(ErrorMessage = "Payment Method is required.")]
        public PaymentMethod PaymentMethod { get; set; }

        [Required(ErrorMessage = "Payment Status is required.")]
        public PaymentStatus PaymentStatus { get; set; }

        [Required(ErrorMessage = "Transaction DateTime is required.")]
        public DateTime TransactionDateTime { get; set; }

        [Required(ErrorMessage = "Home Chef Order ID is required.")]
        public int HomeChefOrderId { get; set; }
    }
}
