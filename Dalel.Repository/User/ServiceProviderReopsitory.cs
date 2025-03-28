using Microsoft.EntityFrameworkCore;
using Models;
using Models.Enums;
using Models.User;

namespace Dalel.Repository
{
    public class ServiceProviderRepository : BaseRepository<ServiceProvider>
    {
        private readonly DelelContext _context;

        public ServiceProviderRepository(DelelContext context) : base(context)
        {
            _context = context;
        }
        public async Task<ServiceProvider> GetProviderWithDetailsAsync(string providerId)
        {
            return await _context.ServiceProviders
                .Include(p => p.Schedules)
                .Include(p => p.Projects)
                .Include(p => p.Propsals)
                    .ThenInclude(pr => pr.ServiceRequest)
                .Include(p => p.CategoryServices)
                .FirstOrDefaultAsync(p => p.UserId == providerId);
        }

        public async Task<IEnumerable<ServiceProvider>> GetProvidersByCategoryAsync(int categoryId)
        {
            return await base.GetList()
                .Where(p => p.CategoryServicesId == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ServiceProvider>> GetTopRatedProvidersAsync(int count)
        {
            return await base.GetList()
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
                .ToListAsync();
        }

        public async Task<bool> ProviderExistsAsync(string providerId)
        {
            return await base.GetList()
                .AnyAsync(p => p.UserId == providerId);
        }

        public async Task<PagedResult<ServiceProvider>> SearchProvidersAsync(
            string searchTerm = null,
            int? categoryId = null,
            double? minRating = null,
            double? maxPrice = null,
            bool? isAvailableNow = null,
            string location = null,
            int pageNumber = 1,
            int pageSize = 10,
            string sortBy = "Rating",
            bool ascending = false)
        {
            var query = base.GetList()
                .Include(p => p.Schedules)
                .Include(p => p.Propsals)
                    .ThenInclude(pr => pr.ServiceRequest)
                        .ThenInclude(sr => sr.Review)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(p => p.AppUser.UserName.Contains(searchTerm) ||
                                      p.AppUser.UserName.Contains(searchTerm) ||
                                      p.AppUser.UserName.Contains(searchTerm));
            }

            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryServicesId == categoryId.Value);
            }

            if (minRating.HasValue)
            {
                query = query.Where(p => p.Propsals
                    .Where(pr => pr.ServiceRequest.Review != null)
                    .Average(pr => (double?)pr.ServiceRequest.Review.Rating) >= minRating.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Propsals
                    .Any(pr => pr.SuggestedPrice <= maxPrice.Value));
            }

            if (isAvailableNow.HasValue && isAvailableNow.Value)
            {
                var now = DateTime.Now;
                var currentDay = now.DayOfWeek;
                var currentTime = TimeOnly.FromDateTime(now);

                query = query.Where(p => p.Schedules.Any(s =>
                    s.WorKDay == (WorKDays)currentDay &&
                    s.AvailableFrom <= currentTime &&
                    s.AvailableTo >= currentTime));
            }

            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(p => p.Address.Contains(location));
            }

            // Sorting
            query = sortBy switch
            {
                "Rating" => ascending
                    ? query.OrderBy(p => p.Propsals
                        .Where(pr => pr.ServiceRequest.Review != null)
                        .Average(pr => pr.ServiceRequest.Review.Rating))
                    : query.OrderByDescending(p => p.Propsals
                        .Where(pr => pr.ServiceRequest.Review != null)
                        .Average(pr => pr.ServiceRequest.Review.Rating)),
                "Price" => ascending
                    ? query.OrderBy(p => p.Propsals.Average(pr => pr.SuggestedPrice))
                    : query.OrderByDescending(p => p.Propsals.Average(pr => pr.SuggestedPrice)),
                "Name" => ascending
                    ? query.OrderBy(p => p.AppUser.UserName)
                    : query.OrderByDescending(p => p.AppUser.UserName),
                _ => query.OrderByDescending(p => p.Propsals
                    .Where(pr => pr.ServiceRequest.Review != null)
                    .Average(pr => pr.ServiceRequest.Review.Rating))
            };

            var result = new PagedResult<ServiceProvider>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = await query.CountAsync()
            };

            result.Items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return result;
        }

        public async Task<PagedResult<ServiceProvider>> GetAvailableProvidersAsync(
            DateTime date,
            TimeOnly time,
            int? categoryId = null,
            int pageNumber = 1,
            int pageSize = 10)
        {
            var day = (WorKDays)date.DayOfWeek;

            var query = base.GetList()
                .Include(p => p.Schedules)
                .Where(p => p.Schedules.Any(s =>
                    s.WorKDay == day &&
                    s.AvailableFrom <= time &&
                    s.AvailableTo >= time))
                .AsQueryable();

            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryServicesId == categoryId.Value);
            }

            var result = new PagedResult<ServiceProvider>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = await query.CountAsync()
            };

            result.Items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return result;
        }
    }
}
