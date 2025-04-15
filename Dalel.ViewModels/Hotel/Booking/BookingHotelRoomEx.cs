using System.Linq;
using Models.Hotel;
using Models.Enums; 

namespace Dalel.ViewModels
{
    public static class BookingHotelRoomEx
    {
        public static BookingHotelRoom ToModel(this BookingHotelRoomCreation bookingVM)
        {
            return new BookingHotelRoom
            {
                RoomId = bookingVM.RoomId,
                ClientId = bookingVM.ClientId,
                Checkin = bookingVM.Checkin,
                Checkout = bookingVM.Checkout,
                NumberOfGuests = bookingVM.NumberOfGuests,
                Price = 0, // Price will be calculated or set via business logic.
                BookingStatus = BookingStatus.Panding, // Assuming a default pending status.
                IsAvailable = true,
                BookingGuestsInRooms = bookingVM.Guests?
                    .Select(g => new BookingGuestInRoom
                    {
                        FullName = g.FullName,
                        NationalId = g.NationalId,
                        NationalIDImage = g.NationalIDImage
                    }).ToList()
            };
        }

        public static BookingHotelRoomDetails ToDetailsViewModel(this BookingHotelRoom booking)
        {
            return new BookingHotelRoomDetails
            {
                Id = booking.Id,
                Checkin = booking.Checkin,
                Checkout = booking.Checkout,
                Price = booking.Price,
                NumberOfGuests = booking.NumberOfGuests,
                BookingStatus = booking.BookingStatus.ToString(),
                RoomId = booking.RoomId,
                HotelId = booking.Id,
                ClientId = booking.ClientId,
                Guests = booking.BookingGuestsInRooms?
                    .Select(g => new BookingGuestInRoomDetails
                    {
                        Id = g.Id,
                        FullName = g.FullName,
                        NationalId = g.NationalId,
                        NationalIDImage = g.NationalIDImage
                    }).ToList() ?? new System.Collections.Generic.List<BookingGuestInRoomDetails>()
            };
        }
    }
}
