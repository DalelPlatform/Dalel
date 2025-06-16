using Dalel.ViewModels;
using Dalel.ViewModels;
using Dalel.ViewModels.Agency.AgencyVerificationDocument;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Enums;
using Models.HomeService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Dalel.Repository
{
    public class ServiceRequestRepository : BaseRepository<ServiceRequest>
    {
        private readonly DelelContext _context;

        public ServiceRequestRepository(DelelContext context) : base(context)
        {
        }
  
        public ServiceRequest GetRequestWithDetails(int requestId)
        {
            return base.GetById(requestId);
        }

        public IQueryable<ServiceRequest> GetRequestsByClient(string clientId, int pageSize)
        {
            return base.GetList(r=>r.ClientId == clientId)
                .OrderByDescending(r => r.Date);
     
        }

        public IQueryable<ServiceRequest> GetRequestsByStatus(RequestStatus status, int pageSize)
        {
            return base.GetList(r => r.Status == status)
                .OrderByDescending(r => r.Date);
      
        }

        public bool RequestExists(int requestId)
        {
            return base.GetList(r => r.Id == requestId)
                .Any();
        }

        //Requests
        public IQueryable<ServiceRequestDetailsVM> GetPendingRequests()
        {
            return GetList(p => p.Status == RequestStatus.Pending).
                Select(req => req.ToDetailsViewModel());
        }
        public IQueryable<ServiceRequestDetailsVM> GetAcceptedRequests()
        {
            return GetList(p => p.Status == RequestStatus.Accepted).
                Select(req => req.ToDetailsViewModel());
        }
        public IQueryable<ServiceRequestDetailsVM> GetRejectedRequests()
        {
            return GetList(p => p.Status == RequestStatus.Rejected).
                Select(req => req.ToDetailsViewModel());
        }
        public IQueryable<ServiceRequestDetailsVM> GetCompletedRequests()
        {
            return GetList(p => p.Status == RequestStatus.Completed).
                Select(req => req.ToDetailsViewModel());
        }
        public IQueryable<ServiceRequestDetailsVM> GetCancelledRequests()
        {
            return GetList(p => p.Status == RequestStatus.Cancelled).
                Select(req => req.ToDetailsViewModel());
        }
        public IQueryable<ServiceRequestDetailsVM> GetAllRequests()
        {
            return GetList(p => p.IsDeleted == false).
                Select(req => req.ToDetailsViewModel());
        }
        public IQueryable<ServiceRequestDetailsVM> GetRequestsByCategory(int categoryId)
        {
            return GetList(p => p.CategoryServicesId == categoryId && p.IsDeleted == false).
                Select(req => req.ToDetailsViewModel());
        }
        public bool UpdaterequestsStatus(int requestsId, RequestStatus newStatus)
        {
            var requests = base.GetList(req => req.Id == requestsId).FirstOrDefault();
            if (requests == null)
                return false;

            requests.Status = newStatus;
            base.Update(requests);
            return true;
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
