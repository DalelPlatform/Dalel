using Dalel.ViewModels;
using Models.Driver;

namespace Dalel.ViewModels
{
    public static class BookingVehicleExt
    {
        public static BookingVehicleDetailsViewModel ToDetailsViewModel(this BookingVehicle booking)
        {
            return new BookingVehicleDetailsViewModel
            {
                Id = booking.Id,
                PickupLocation = booking.PickupLocation,
                DropoffLocation = booking.DropoffLocation,
                SuggestedPrice = booking.SuggestedPrice,
                BookingStatus = booking.BookingStatus.ToString(),
                PassengersNo = booking.PassengersNo,
                StartedDateTime = booking.StartedDateTime,
                EndedDateTime = booking.EndedDateTime,
                ClientName = booking.Client?.User?.UserName,  // تأكد من عدم وجود Null
                ClientEmail = booking.Client?.User?.Email
            };
        }
    }
}
