using System;
using Models.Enums;

namespace Dalel.ViewModels
{
    public class PaymentHomeChefOrderDetailsVM
    {
        public float Amount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal? CommissionDeducted { get; set; }
        public string? CodeApplied { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime TransactionDateTime { get; set; }
    }
}
