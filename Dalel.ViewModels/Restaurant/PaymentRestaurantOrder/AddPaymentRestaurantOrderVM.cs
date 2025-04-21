using System;
using System.ComponentModel.DataAnnotations;
using Models.Enums; // Adjust namespace if your enums are in a different folder

namespace Dalel.ViewModels.Restaurant
{
    public class AddPaymentRestaurantOrderVM
    {
        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.0, float.MaxValue, ErrorMessage = "Amount must be a positive number.")]
        public float Amount { get; set; }

        [Required(ErrorMessage = "AmountPaid is required.")]
        [Range(0.0, double.MaxValue, ErrorMessage = "AmountPaid must be a positive number.")]
        public decimal AmountPaid { get; set; }

        [Range(0.0, double.MaxValue, ErrorMessage = "CommissionDeducted must be a positive number.")]
        public decimal? CommissionDeducted { get; set; }

        [MaxLength(100, ErrorMessage = "CodeApplied can't be longer than 100 characters.")]
        public string? CodeApplied { get; set; }

        [Required(ErrorMessage = "PaymentType is required.")]
        public PaymentMethod PaymentType { get; set; }

        [Required(ErrorMessage = "PaymentStatus is required.")]
        public PaymentStatus PaymentStatus { get; set; }

        [Required(ErrorMessage = "TransactionDateTime is required.")]
        public DateTime TransactionDateTime { get; set; }

        [Required(ErrorMessage = "RestaurantOrderId is required.")]
        public int RestaurantOrderId { get; set; }
    }
}
