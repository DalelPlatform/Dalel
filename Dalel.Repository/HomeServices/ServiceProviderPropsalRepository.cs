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
    public class ServiceProviderPropsalRepository : BaseRepository<ServiceProviderPropsal>
    {

        private readonly DelelContext _context;

        public ServiceProviderPropsalRepository(DelelContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceProviderPropsal>> GetProposalsByRequestAsync(int requestId)
        {
            return await _context.ServiceProviderPropsals
                .Include(p => p.ServiceProvider)
                .Include(p => p.ServiceRequest)
                .Where(p => p.ServiceRequestId == requestId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ServiceProviderPropsal>> GetProposalsByProviderAsync(string providerId)
        {
            return await _context.ServiceProviderPropsals
                .Include(p => p.ServiceRequest)
                .Where(p => p.ServiceProviderId == providerId)
                .ToListAsync();
        }

        public async Task<ServiceProviderPropsal> GetProposalWithDetailsAsync(int proposalId)
        {
            return await _context.ServiceProviderPropsals
                .Include(p => p.ServiceProvider)
                .Include(p => p.ServiceRequest)
                .FirstOrDefaultAsync(p => p.Id == proposalId);
        }

        public async Task<bool> HasProviderProposedAsync(int requestId, string providerId)
        {
            return await _context.ServiceProviderPropsals
                .AnyAsync(p => p.ServiceRequestId == requestId && p.ServiceProviderId == providerId);
        }

        public async Task AcceptProposalAsync(int proposalId)
        {
            var proposal = await _context.ServiceProviderPropsals.FindAsync(proposalId);
            if (proposal != null)
            {
                proposal.Status = ProposalStatus.Accepted;
                var request = await _context.ServiceRequests.FindAsync(proposal.ServiceRequestId);
                if (request != null)
                {
                    request.Status = RequestStatus.Pending;
                }
            }
        }

        public async Task RejectProposalAsync(int proposalId)
        {
            var proposal = await _context.ServiceProviderPropsals.FindAsync(proposalId);
            if (proposal != null)
            {
                proposal.Status = ProposalStatus.Rejected;
            }
        }

        //public async Task<PagedResult<ServiceProviderPropsal>> FilterProposalsAsync(
        //    int? requestId = null,
        //    string providerId = null,
        //    ProposalStatus? status = null,
        //    double? minPrice = null,
        //    double? maxPrice = null,
        //    DateTime? fromDate = null,
        //    DateTime? toDate = null,
        //    int pageNumber = 1,
        //    int pageSize = 10,
        //    string sortBy = "SuggestedPrice",
        //    bool ascending = true)
        //{
        //    var query = _context.ServiceProviderPropsals
        //        .Include(p => p.ServiceProvider)
        //        .Include(p => p.ServiceRequest)
        //        .AsQueryable();

        //    if (requestId.HasValue)
        //    {
        //        query = query.Where(p => p.ServiceRequestId == requestId.Value);
        //    }

        //    if (!string.IsNullOrEmpty(providerId))
        //    {
        //        query = query.Where(p => p.ServiceProviderId == providerId);
        //    }

        //    if (status.HasValue)
        //    {
        //        query = query.Where(p => p.Status == status.Value);
        //    }

        //    if (minPrice.HasValue)
        //    {
        //        query = query.Where(p => p.SuggestedPrice >= minPrice.Value);
        //    }

        //    if (maxPrice.HasValue)
        //    {
        //        query = query.Where(p => p.SuggestedPrice <= maxPrice.Value);
        //    }

        //    if (fromDate.HasValue)
        //    {
        //        query = query.Where(p => p.ServiceRequest.Date >= fromDate.Value);
        //    }

        //    if (toDate.HasValue)
        //    {
        //        query = query.Where(p => p.ServiceRequest.Date <= toDate.Value);
        //    }

        //    // Sorting
        //    query = sortBy switch
        //    {
        //        "SuggestedPrice" => ascending
        //            ? query.OrderBy(p => p.SuggestedPrice)
        //            : query.OrderByDescending(p => p.SuggestedPrice),
        //        "Date" => ascending
        //            ? query.OrderBy(p => p.ServiceRequest.Date)
        //            : query.OrderByDescending(p => p.ServiceRequest.Date),
        //        "Status" => ascending
        //            ? query.OrderBy(p => p.Status)
        //            : query.OrderByDescending(p => p.Status),
        //        _ => query.OrderBy(p => p.SuggestedPrice)
        //    };

        //    var result = new PagedResult<ServiceProviderPropsal>
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
