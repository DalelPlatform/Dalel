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


    public class BookingHotelRoomRepository : GenericHotelRepo<BookingHotelRoom>
    {
        private readonly DelelContext _context;

        public BookingHotelRoomRepository(DelelContext context):base(context) 
        {
            _context = context;
        }

        public async Task<List<BookingHotelRoom>> GetBookingsByClientIdAsync(int clientId)
        {
            return await _context.BookingHotelRooms
                                 .Where(b => b.ClientId == clientId.ToString())
                                 .ToListAsync();
        }

        public async Task<List<BookingHotelRoom>> GetBookingsByDateRangeAsync(DateTime checkIn, DateTime checkOut)
        {
            return await _context.BookingHotelRooms
                                 .Where(b => b.Checkin >= checkIn && b.Checkout <= checkOut)
                                 .ToListAsync();
        }

        public async Task<List<BookingHotelRoom>> GetAvailableRoomAsync()
        {
            return await _context.BookingHotelRooms
                                 .Where(b => b.IsAvailable)
                                 .ToListAsync();
        }

    }

}
