using Models.Driver;
using Dalel.ViewModels;

namespace Dalel.ViewModels
{
    public static class PaymentVehicleExtensions
    {
        public static PaymentVehicleDetailsViewModel ToDetailsViewModel(this PaymentVehicle payment)
        {
            return new PaymentVehicleDetailsViewModel
            {
                Id = payment.Id,
                Amount = payment.Amount,
                PaymentMethod = payment.PaymentMethod,
                PaymentStatus = payment.PaymentStatus,
                TransactionDateTime = payment.TransactionDateTime,
                BookingVehicleId = payment.BookingVehicleId,
                ClientName = payment.BookingVehicle?.Client?.User?.UserName ?? "N/A",
                ClientEmail = payment.BookingVehicle?.Client?.User?.Email ?? "N/A"
            };
        }
    }
}
