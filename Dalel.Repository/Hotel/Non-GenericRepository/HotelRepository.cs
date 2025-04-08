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
    public class HotelRepository : GenericHotelRepo<Models.Hotel.Hotel>
    {
        private readonly DelelContext _context;

        public HotelRepository(DelelContext context) : base(context)
        {
            _context = context;
        }

        // Specific method to get hotels by city
        public async Task<IEnumerable<Models.Hotel.Hotel>> GetHotelsByCityAsync(string city)
        {
            return (IEnumerable<Models.Hotel.Hotel>)await Task.FromResult(GetByConditionAsync(h => h.City == city && !h.IsDeleted));
        }

        public async Task<Models.Hotel.Hotel> GetHotelByOwnerIdAsync(string ownerId)
        {
            return await _context.Set<Models.Hotel.Hotel>()
                                 .FirstOrDefaultAsync(h => h.OwnerId == ownerId);
        }

    }
}
