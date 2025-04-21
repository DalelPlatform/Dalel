using System;
using Models.Enums; // Adjust if your enums are in a different namespace

namespace Dalel.ViewModels.Restaurant
{
    public class PaymentRestaurantOrderDetailsVM
    {
        public int Id { get; set; }

        public float Amount { get; set; }

        public decimal AmountPaid { get; set; }

        public decimal? CommissionDeducted { get; set; }

        public string? CodeApplied { get; set; }

        public PaymentMethod PaymentType { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public DateTime TransactionDateTime { get; set; }

        public int RestaurantOrderId { get; set; }

        // Optionally include restaurant order summary info if needed
        // public RestaurantOrderDetailsVM RestaurantOrder { get; set; }
    }
}
