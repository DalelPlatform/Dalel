using System;

namespace Dalel.ViewModels
{
    public class HotelPaymentDetails
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal? CommissionDeducted { get; set; }
        public string? CodeApplied { get; set; }
        public string PaymentMethod { get; set; } // Enum: PaymentMethod
        public string PaymentStatus { get; set; } // Enum: PaymentStatus
        public DateTime TransactionDateTime { get; set; }
        public int BookingHotelRoomId { get; set; }
        public int ClientId { get; set; }
        public int HotelId { get; set; }
        public string Status { get; set; }
    }
}
