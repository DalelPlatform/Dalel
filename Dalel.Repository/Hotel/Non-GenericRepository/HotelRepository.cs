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
    public class HotelRepository : GenericHotelRepo<Models.Hotel.Hotel>
    {
        private readonly DelelContext _context;

        public HotelRepository(DelelContext context) : base(context)
        {
            _context = context;
        }

        // Specific method to get hotels by city
        public IEnumerable<Models.Hotel.Hotel> GetHotelsByCity(string city)
        {
            return GetByCondition(h => h.City == city && !h.IsDeleted);
        }

        // Specific method to get a hotel by its owner
        public Models.Hotel.Hotel GetHotelByOwnerId(string ownerId)
        {
            return _context.Set<Models.Hotel.Hotel>().FirstOrDefault(h => h.OwnerId == ownerId);
        }
    }
}
