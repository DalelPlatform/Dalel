using Dalel.Repository.GenericHotelRepo;
using Models;
using Models.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Repository.Hotel.Non_GenericRepository
{


    public class BookingHotelRoomRepository : GenericHotelRepo<BookingHotelRoom>
    {
        private readonly DelelContext _context;

        public BookingHotelRoomRepository(DelelContext context):base(context) 
        {
            _context = context;
        }

        public List<BookingHotelRoom> GetBookingsByClientId(int clientId)
        {
            return _context.BookingHotelRooms
                           .Where(b => b.ClientId == clientId.ToString())
                           .ToList();
        }

        public List<BookingHotelRoom> GetBookingsByDateRange(DateTime checkIn, DateTime checkOut)
        {
            return _context.BookingHotelRooms
                           .Where(b => b.Checkin >= checkIn && b.Checkout <= checkOut)
                           .ToList();
        }

        public List<BookingHotelRoom> GetAvailableRoom()
        {
            return _context.BookingHotelRooms
                           .Where(b => b.IsAvailable)
                           .ToList();
        }
    }

}
