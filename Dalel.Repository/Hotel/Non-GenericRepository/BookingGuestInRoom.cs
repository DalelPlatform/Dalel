using Dalel.Repository.GenericHotelRepo;
using Models;
using Models.Hotel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public async Task<List<BookingGuestInRoom>> GetGuestsByBookingIdAsync(int bookingId)
        {
            return await _context.BookingGuestInRooms
                                 .Where(g => g.BookingId == bookingId)
                                 .ToListAsync();
        }

        public async Task<BookingGuestInRoom> GetGuestByNationalIdAsync(string nationalId)
        {
            return await _context.BookingGuestInRoom
                                 .FirstOrDefaultAsync(g => g.NationalId == nationalId);
        }

    }
}
