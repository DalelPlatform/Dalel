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
        public async Task<IEnumerable<RoomType>> GetRoomTypesByHotelIdAsync(int hotelId)
        {
            return (IEnumerable<RoomType>)await Task.FromResult(GetByConditionAsync(rt => rt.HotelId == hotelId));
        }

        public async Task<IEnumerable<RoomType>> GetExpensiveRoomTypesAsync(float priceThreshold)
        {
            return (IEnumerable<RoomType>)await Task.FromResult(GetByConditionAsync(rt => rt.Price > priceThreshold));
        }

    }
}
