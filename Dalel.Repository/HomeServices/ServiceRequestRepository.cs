using Models.Enums;
using Models.HomeService;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Dalel.Repository
{
    public class ServiceRequestRepository : BaseRepository<ServiceRequest>
    {
        private readonly DelelContext _context;

        public ServiceRequestRepository(DelelContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ServiceRequest> GetRequestWithDetailsAsync(int requestId)
        {
            return await _context.ServiceRequests
                .Include(r => r.Client)
                .Include(r => r.Propsals)
                .Include(r => r.Payment)
                .Include(r => r.Review)
                .FirstOrDefaultAsync(r => r.Id == requestId);
        }

        public async Task<IEnumerable<ServiceRequest>> GetRequestsByClientAsync(string clientId)
        {
            return await _context.ServiceRequests
                .Where(r => r.ClientId == clientId)
                .OrderByDescending(r => r.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<ServiceRequest>> GetRequestsByStatusAsync(RequestStatus status)
        {
            return await _context.ServiceRequests
                .Where(r => r.Status == status)
                .ToListAsync();
        }

        public async Task<bool> RequestExistsAsync(int requestId)
        {
            return await _context.ServiceRequests
                .AnyAsync(r => r.Id == requestId);
        }

        //public async Task<PagedResult<ServiceRequest>> FilterRequestsAsync(
        //    string clientId = null,
        //    string providerId = null,
        //    int? categoryId = null,
        //    RequestStatus? status = null,
        //    DateTime? fromDate = null,
        //    DateTime? toDate = null,
        //    double? minPrice = null,
        //    double? maxPrice = null,
        //    bool? hasProposals = null,
        //    bool? hasReview = null,
        //    int pageNumber = 1,
        //    int pageSize = 10,
        //    string sortBy = "Date",
        //    bool ascending = false)
        //{
        //    var query = _context.ServiceRequests
        //        .Include(r => r.Propsals)
        //        .Include(r => r.Review)
        //        .AsQueryable();

        //    if (!string.IsNullOrEmpty(clientId))
        //    {
        //        query = query.Where(r => r.ClientId == clientId);
        //    }

        //    if (!string.IsNullOrEmpty(providerId))
        //    {
        //        query = query.Where(r => r.Propsals.Any(p => p.ServiceProviderId == providerId));
        //    }

        //    if (categoryId.HasValue)
        //    {
        //        query = query.Where(r => r.Propsals.Any(p => p.ServiceProvider.CategoryServicesId == categoryId.Value));
        //    }

        //    if (status.HasValue)
        //    {
        //        query = query.Where(r => r.Status == status.Value);
        //    }

        //    if (fromDate.HasValue)
        //    {
        //        query = query.Where(r => r.Date >= fromDate.Value);
        //    }

        //    if (toDate.HasValue)
        //    {
        //        query = query.Where(r => r.Date <= toDate.Value);
        //    }

        //    if (minPrice.HasValue)
        //    {
        //        query = query.Where(r => r.StartPrice >= minPrice.Value);
        //    }

        //    if (maxPrice.HasValue)
        //    {
        //        query = query.Where(r => r.StartPrice <= maxPrice.Value);
        //    }

        //    if (hasProposals.HasValue)
        //    {
        //        query = hasProposals.Value
        //            ? query.Where(r => r.Propsals.Any())
        //            : query.Where(r => !r.Propsals.Any());
        //    }

        //    if (hasReview.HasValue)
        //    {
        //        query = hasReview.Value
        //            ? query.Where(r => r.Review != null)
        //            : query.Where(r => r.Review == null);
        //    }

        //    // Sorting
        //    query = sortBy switch
        //    {
        //        "Date" => ascending ? query.OrderBy(r => r.Date) : query.OrderByDescending(r => r.Date),
        //        "Price" => ascending ? query.OrderBy(r => r.StartPrice) : query.OrderByDescending(r => r.StartPrice),
        //        "Status" => ascending ? query.OrderBy(r => r.Status) : query.OrderByDescending(r => r.Status),
        //        _ => query.OrderByDescending(r => r.Date)
        //    };

        //    var result = new PagedResult<ServiceRequest>
        //    {
        //        PageNumber = pageNumber,
        //        PageSize = pageSize,
        //        TotalCount = await query.CountAsync()
        //    };

        //    result.Items = await query
        //        .Skip((pageNumber - 1) * pageSize)
        //        .Take(pageSize)
        //        .ToListAsync();

        //    return result;
        //}
    }
}
