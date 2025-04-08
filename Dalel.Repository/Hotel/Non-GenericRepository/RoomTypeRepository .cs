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
    public class RoomTypeRepository : GenericHotelRepo<RoomType>
    {
        private readonly DelelContext _context;

        public RoomTypeRepository(DelelContext context) : base(context)
        {
            _context = context;
        }

        // Specific method to get room types by hotel ID
        public IEnumerable<RoomType> GetRoomTypesByHotelId(int hotelId)
        {
            return GetByCondition(rt => rt.HotelId == hotelId);
        }

        // Specific method to get room types with price greater than a certain value
        public IEnumerable<RoomType> GetExpensiveRoomTypes(float priceThreshold)
        {
            return GetByCondition(rt => rt.Price > priceThreshold);
        }
    }
}
