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
    public class PaymentHotelRoomRepository : GenericHotelRepo<PaymentHotelRoom>, IGenericHotelRepo<PaymentHotelRoom>
    {
        private readonly DelelContext _context;

        public PaymentHotelRoomRepository(DelelContext context):base(context) 
        {
            _context = context;
        }

        public List<PaymentHotelRoom> GetPaymentsByStatus(string status)
        {
            return _context.PaymentHotelRoom
                           .Where(p => p.Status == status)
                           .ToList();
        }

        public List<PaymentHotelRoom> GetPaymentsForHotel(int hotelId)
        {
            return _context.PaymentHotelRoom
                           .Where(p => p.HotelId == hotelId)
                           .ToList();
        }

        public List<PaymentHotelRoom> GetPaymentsForClient(int clientId)
        {
            return _context.PaymentHotelRoom
                           .Where(p => p.ClientId == clientId)
                           .ToList();
        }
    }
}
