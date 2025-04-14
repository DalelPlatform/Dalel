using Models.Hotel;

namespace Dalel.ViewModels
{
    public static class HotelPaymentEx
    {
        public static HotelPaymentDetails ToDetailsViewModel(this PaymentHotelRoom payment)
        {
            return new HotelPaymentDetails
            {
                Id = payment.Id,
                Amount = payment.Amount,
                AmountPaid = payment.AmountPaid,
                CommissionDeducted = payment.CommissionDeducted,
                CodeApplied = payment.CodeApplied,
                PaymentMethod = payment.PaymentMethod.ToString(),
                PaymentStatus = payment.PaymentStatus.ToString(),
                TransactionDateTime = payment.TransactionDateTime,
                BookingHotelRoomId = payment.BookingHotelRoomId,
                ClientId = payment.ClientId,
                HotelId = payment.HotelId,
                Status = payment.Status
            };
        }
    }
}
