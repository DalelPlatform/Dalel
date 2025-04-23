using Microsoft.EntityFrameworkCore;
using Models;
using Models.Enums;
using Models.HomeService;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Dalel.Repository
{
    public class ServiceProviderReviewRepository : BaseRepository<ServiceProviderReview>
    {
        private readonly DelelContext _context;

        public ServiceProviderReviewRepository(DelelContext delelContext) : base(delelContext)
        {
        }

        // Get review by request
        public ServiceProviderReview GetReviewByRequest(int requestId)
        {
            return base.Get(r=> r.Id ==  requestId).FirstOrDefault();

        }

        // Get reviews by provider with pagination
        public IQueryable<ServiceProviderReview> GetReviewsByProvider(string providerId, int pageSize = 10, int pageNumber = 1)
        {
            IQueryable<ServiceProviderReview> query = _context.ServiceProviderReviews
                .Include(r => r.ServiceRequest)
                .Where(r => r.ServiceRequest.Propsals.Any(p => p.ServiceProviderId == providerId && p.Status == ProposalStatus.Accepted));

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
            return query.OrderByDescending(r => r.ReviewDate)
                        .Skip(skip)
                        .Take(pageSize);
        }

        // Add a new review
        public bool AddReview(ServiceProviderReview review)
        {
            review.ReviewDate = DateTime.Now;
            base.Add(review);
            base.Save();
            return true;
        }
    }
}