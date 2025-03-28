using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;
using Models.Enums;
using Models.HomeService;
using Models.User;
using System.Linq.Expressions;

namespace Dalel.Repository
{
    public class ServiceProviderRepository : BaseRepository<ServiceProvider>
    {
        private readonly DelelContext _context;
        public ServiceProviderRepository(DelelContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ServiceProvider> GetWithDetails(string userId = null)
        {
            var query = base.GetList();

            if (!string.IsNullOrEmpty(userId))
                query = query.Where(x => x.UserId == userId);

            return query;
        }

        public IQueryable<ServiceProvider> GetVerifiedProviders(int? categoryId = null)
        {
            var query = GetList(x => x.VerificationStatus == VerificationStatus.Confirmed);

            if (categoryId.HasValue)
                query = query.Where(x => x.CategoryServicesId == categoryId.Value);

            return query;
        }
    }

 
}