using Models.Enums;
using System;

namespace Dalel.ViewModels
{
    public class PaymentVehicleDetailsViewModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public int BookingVehicleId { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
    }
}
