using Dalel.Repository;
using Dalel.ViewModels;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Driver;
using System.Linq;

namespace Dalel.Reopsitory
{
    public class VehicleRepository : BaseRepository<Vehicle>
    {
        public VehicleRepository(DelelContext context) : base(context) { }

        
        public VehicleDetailsViewModel GetVehicleWithDetails(int vehicleId)
        {
            return base.GetList(v => v.Id == vehicleId)
                       .Select(v => v.ToDetailsViewModel())
                       .FirstOrDefault();
        }

        
        public IQueryable<VehicleDetailsViewModel> GetVehiclesByType(string type)
        {
            return GetList(v => v.Type == type).Select(v => v.ToDetailsViewModel());
        }

        
        public IQueryable<Vehicle> Search(string searchTerm = "", string sortBy = "Type", bool descending = false)
        {
            var query = base.GetList();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                string lowerSearchTerm = searchTerm.ToLower();
                query = query.Where(v =>
                    v.Type.ToLower().Contains(lowerSearchTerm) ||
                    v.Driver.AppUser.UserName.ToLower().Contains(lowerSearchTerm) ||
                    v.Id.ToString().Contains(lowerSearchTerm)
                );
            }

            
            query = descending ? query.OrderByDescending(v => EF.Property<object>(v, sortBy))
                                : query.OrderBy(v => EF.Property<object>(v, sortBy));

            return query;
        }
    }
}
