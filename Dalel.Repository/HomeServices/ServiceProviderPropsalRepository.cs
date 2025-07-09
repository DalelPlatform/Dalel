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
        }

        public IQueryable<ServiceProviderPropsal> GetProposalsByRequest(int requestId)
        {
            return base.GetList(p => p.ServiceRequestId == requestId).OrderByDescending(p => p.Id);
        }

        public IQueryable<ServiceProviderPropsal> GetProposalsByProvider(string providerId)
        {
            return base.GetList(p => p.ServiceProviderId == providerId).OrderByDescending(p => p.Id);
        }

        public ServiceProviderPropsal GetProposalWithDetails(int proposalId)
        {
            return base.Get(p => p.Id == proposalId).FirstOrDefault();
        }

        public bool HasProviderProposed(int requestId, string providerId)
        {
            return base.Get(p => p.ServiceRequestId == requestId && p.ServiceProviderId == providerId).Any();
        }

        public void AcceptProposal(int proposalId)
        {
            var proposal = base.Get(p => p.Id == proposalId).FirstOrDefault();
            if (proposal == null || proposal.Status != ProposalStatus.Pending)
                return;

            proposal.Status = ProposalStatus.Accepted;
            // Update the service request status to In Progress
            var request = base.GetById(proposal.ServiceRequestId);
            if (request != null)
            {
                request.Status = ProposalStatus.Accepted;

                var otherProposals = base.Get(p => p.ServiceRequestId == request.Id && p.Id != proposalId);
                foreach (var other in otherProposals)
                {
                    other.Status = ProposalStatus.Rejected;
                }
            }

            base.Save();
        }


        public void RejectProposal(int proposalId)
        {
            var proposal = base.Get(p => p.Id == proposalId).FirstOrDefault();
            if (proposal != null)
            {
                proposal.Status = ProposalStatus.Rejected;
                base.Save();
            }
        }

        public void CompleteProposal(int proposalId)
        {
            var proposal = base.Get(p => p.Id == proposalId).FirstOrDefault();
            if (proposal != null && proposal.Status == ProposalStatus.Accepted)
            {
                proposal.Status = ProposalStatus.Completed;
                base.Save();
            }
        }
        public void AddProposal(ServiceProviderPropsal proposal)
        {
            base.Add(proposal);
            base.Save();

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
