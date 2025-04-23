using Microsoft.EntityFrameworkCore;
using Models;
using Models.Enums;
using Models.User;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Dalel.Repository
{
    public class ServiceProviderRepository : BaseRepository<ServiceProvider>
    {
        private readonly DelelContext DelelContext;
        public ServiceProviderRepository(DelelContext delelContext) : base(delelContext)
        {
            DelelContext = delelContext;
        }

        // Get provider with details
        public ServiceProvider GetProviderWithDetails(string providerId)
        {
            return DelelContext.ServiceProviders
                .Include(p => p.Schedules)
                .Include(p => p.Projects)
                .Include(p => p.Propsals)
                    .ThenInclude(pr => pr.ServiceRequest)
                .Include(p => p.CategoryServices)
                .FirstOrDefault(p => p.UserId == providerId);
        }

        // Get providers by category with pagination
        public IQueryable<ServiceProvider> GetProvidersByCategory(int categoryId, int pageSize = 10, int pageNumber = 1)
        {
            IQueryable<ServiceProvider> query = GetList()
                .Where(p => p.CategoryServicesId == categoryId);

            // Apply pagination
            if (pageSize < 1) pageSize = 10;
            if (pageNumber < 1) pageNumber = 1;

            int count = query.Count();
            if (count < pageSize)
            {
                pageSize = count;
                pageNumber = 1;
            }

            int skip = (pageNumber - 1) * pageSize;
            return query.Skip(skip)
                        .Take(pageSize);
        }

        // Get top-rated providers
        public IQueryable<ServiceProvider> GetTopRatedProviders(int count)
        {
            return (IQueryable<ServiceProvider>)GetList()
                .Select(p => new
                {
                    Provider = p,
                    AvgRating = p.Propsals
                        .Where(pr => pr.ServiceRequest.Review != null)
                        .Average(pr => (double?)pr.ServiceRequest.Review.Rating) ?? 0.0
                })
                .OrderByDescending(x => x.AvgRating)
                .Take(count)
                .Select(x => x.Provider)
                .ToList();
        }

        // Check if provider exists
        public bool ProviderExists(string providerId)
        {
            return GetList()
                .Any(p => p.UserId == providerId);
        }
    }
}