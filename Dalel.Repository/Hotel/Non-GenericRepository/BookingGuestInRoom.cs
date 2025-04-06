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
    public class BookingGuestInRoomRepository : GenericHotelRepo<BookingGuestInRoom>
    {
        private readonly DelelContext _context;

        public BookingGuestInRoomRepository(DelelContext context):base(context) 
        {
            _context = context;
        }

        public List<BookingGuestInRoom> GetGuestsByBookingId(int bookingId)
        {
            return _context.BookingGuestInRooms
                           .Where(g => g.BookingId == bookingId)
                           .ToList();
        }

        public BookingGuestInRoom GetGuestByNationalId(string nationalId)
        {
            return _context.BookingGuestInRoom
                           .FirstOrDefault(g => g.NationalId == nationalId);
        }
    }
}
