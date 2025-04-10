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
    public class PaymentHotelRoomRepository : GenericHotelRepo<PaymentHotelRoom>
    {
        private readonly DelelContext _context;

        public PaymentHotelRoomRepository(DelelContext context):base(context) 
        {
            _context = context;
        }

        public async Task<List<PaymentHotelRoom>> GetPaymentsByStatusAsync(string status)
        {
            return await _context.PaymentHotelRoom
                                 .Where(p => p.Status == status)
                                 .ToListAsync();
        }

        public async Task<List<PaymentHotelRoom>> GetPaymentsForHotelAsync(int hotelId)
        {
            return await _context.PaymentHotelRoom
                                 .Where(p => p.HotelId == hotelId)
                                 .ToListAsync();
        }

        public async Task<List<PaymentHotelRoom>> GetPaymentsForClientAsync(int clientId)
        {
            return await _context.PaymentHotelRoom
                                 .Where(p => p.ClientId == clientId)
                                 .ToListAsync();
        }

    }
}
