using Dalel.ViewModels.Hotel.HotelPayment;
using Models.Hotel;

namespace Dalel.ViewModels
{
    public static class HotelPaymentEx
    {
        public static PaymentHotelRoom ToModel(this PaymentHotelRoomCreation vm)
        {
            return new PaymentHotelRoom
            {
                Amount = vm.Amount,
                AmountPaid = vm.AmountPaid,
                CommissionDeducted = vm.CommissionDeducted,
                CodeApplied = vm.CodeApplied,
                PaymentMethod = vm.PaymentMethod,
                PaymentStatus = vm.PaymentStatus,
                TransactionDateTime = vm.TransactionDateTime,
                BookingHotelRoomId = vm.BookingHotelRoomId,
                ClientId = vm.ClientId,
                HotelId = vm.HotelId
            };
        }

        public static PaymentHotelRoom UpdateModel(this PaymentHotelRoom existing, PaymentHotelRoomCreation vm)
        {
            existing.Amount = vm.Amount;
            existing.AmountPaid = vm.AmountPaid;
            existing.CommissionDeducted = vm.CommissionDeducted;
            existing.CodeApplied = vm.CodeApplied;
            existing.PaymentMethod = vm.PaymentMethod;   
            existing.PaymentStatus = vm.PaymentStatus;
            existing.TransactionDateTime = vm.TransactionDateTime;
            existing.BookingHotelRoomId = vm.BookingHotelRoomId;
            existing.ClientId = vm.ClientId;
            existing.HotelId = vm.HotelId;

            return existing;
        }
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
            };
        }
    }
}
