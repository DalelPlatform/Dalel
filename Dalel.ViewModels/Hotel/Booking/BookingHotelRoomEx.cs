using System.Linq;
using Models.Hotel;
using Models.Enums; 

namespace Dalel.ViewModels
{
    public static class BookingHotelRoomEx
    {
        //Creation
        public static BookingHotelRoom ToModel(this BookingHotelRoomCreation bookingVM)
        {
            return new BookingHotelRoom
            {
                RoomId = bookingVM.RoomId,
                ClientId = bookingVM.ClientId,
                Checkin = bookingVM.Checkin,
                Checkout = bookingVM.Checkout,
                NumberOfGuests = bookingVM.NumberOfGuests,
                Price = 0, 
                BookingStatus = BookingStatus.Panding, 
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
                RoomId = booking.RoomId,
                ClientId = booking.ClientId,
                Checkin = booking.Checkin,
                Checkout = booking.Checkout,
                NumberOfGuests = booking.NumberOfGuests,
                Price = booking.Price,
                BookingStatus = booking.BookingStatus.ToString(),

            };
        }

        public static BookingHotelRoom UpdateModel(this BookingHotelRoom existingBooking, BookingHotelRoomCreation bookingVM )
        {
            existingBooking.RoomId = bookingVM.RoomId != 0 ? bookingVM.RoomId : existingBooking.RoomId;
            existingBooking.ClientId = bookingVM.ClientId != null ? bookingVM.ClientId : existingBooking.ClientId;
            existingBooking.Checkin = bookingVM.Checkin != default ? bookingVM.Checkin : existingBooking.Checkin;
            existingBooking.Checkout = bookingVM.Checkout != default ? bookingVM.Checkout : existingBooking.Checkout;
            existingBooking.NumberOfGuests = bookingVM.NumberOfGuests != 0 ? bookingVM.NumberOfGuests : existingBooking.NumberOfGuests;

            if (bookingVM.Guests != null && bookingVM.Guests.Any())
            {
                existingBooking.BookingGuestsInRooms = bookingVM.Guests
                    .Select(g => new BookingGuestInRoom
                    {
                        FullName = g.FullName,
                        NationalId = g.NationalId,
                        NationalIDImage = g.NationalIDImage
                    }).ToList();
            }

            return existingBooking;
        }
    }
}

