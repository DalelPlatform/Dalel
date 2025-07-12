using Microsoft.EntityFrameworkCore;
using Models;
using Models.Enums;
using Models.User;
using System.Data.Entity;
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
            return base.GetList(sp => sp.UserId == providerId).FirstOrDefault();

        }
        public bool CheckProfileCompleteness(string userId)
        {
            var serviceProvider = GetProviderWithDetails(userId);
            if (serviceProvider == null)
            {
                return false;
            }
            return !string.IsNullOrWhiteSpace(serviceProvider.Address) &&
                   !string.IsNullOrWhiteSpace(serviceProvider.City) &&
                   !string.IsNullOrWhiteSpace(serviceProvider.Country) &&
                   !string.IsNullOrWhiteSpace(serviceProvider.District) &&
                   !string.IsNullOrWhiteSpace(serviceProvider.ZipCode) &&
                   !string.IsNullOrWhiteSpace(serviceProvider.ServiceArea) &&
                   !string.IsNullOrWhiteSpace(serviceProvider.About) &&
                   serviceProvider.Price.HasValue &&
                   !string.IsNullOrWhiteSpace(serviceProvider.PriceUnit) &&
                   serviceProvider.Schedules != null && serviceProvider.Schedules.Any();
        }
        // Get providers by category with pagination
        public IQueryable<ServiceProvider> GetProvidersByCategory(int categoryId)
        {
            return base.GetList(p => p.CategoryServicesId == categoryId);
        }

        // Get top-rated providers
        public IQueryable<ServiceProvider> GetTopRatedProviders(int count)
        {
            var query = base.GetList()
                .Select(p => new
                {
                    Provider = p,
                    AvgRating = p.Propsals
                        .Where(pr => pr.ServiceRequest.Review != null)
                        .Average(pr => (double?)pr.ServiceRequest.Review.Rating) ?? 0.0
                })
                .OrderByDescending(x => x.AvgRating)
                .Take(count)
                .Select(x => x.Provider);

            return query;
        }
        public ServiceProvider GetProvider(string Id)
        {
            return base.GetById(Id);
        }

        // Check if provider exists
        public bool ProviderExists(string providerId)
        {
            return base.GetList(p => p.UserId == providerId).Any();
        }

        public IQueryable<ServiceProvider> SearchProviders(
    string searchText = null,
    int? categoryId = null,
    string address = null,
    int? verificationStatus = null,
    string sortBy = "Name",
    bool descending = false)
        {
            var query = base.GetList();

            if (!string.IsNullOrEmpty(searchText))
                query = query.Where(p => p.AppUser.UserName.Contains(searchText));

            if (categoryId.HasValue)
                query = query.Where(p => p.CategoryServicesId == categoryId.Value);

            if (!string.IsNullOrEmpty(address))
                query = query.Where(p => p.Address.Contains(address));

            query = sortBy.ToLower() switch
            {
                "name" => descending ? query.OrderByDescending(p => p.AppUser.UserName) : query.OrderBy(p => p.AppUser.UserName),
                "date" => descending ? query.OrderByDescending(p => p.AppUser.ModificationDate) : query.OrderBy(p => p.AppUser.ModificationDate),
                _ => query.OrderBy(p => p.AppUser.UserName)
            };

            return query;
        }

    }
}