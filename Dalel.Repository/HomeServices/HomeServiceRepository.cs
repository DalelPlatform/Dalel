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
        public ServiceProviderRepository(DelelContext context) : base(context) { }

        public IQueryable<ServiceProvider> GetWithDetails(string userId = null)
        {
            var query = Table.AsQueryable();

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

    public class CategoryServicesRepository : BaseRepository<CategoryServices>
    {
        public CategoryServicesRepository(DelelContext context) : base(context) { }

        public IQueryable<CategoryServices> GetPopularCategories(int count = 5)
        {
            return GetList()
                .OrderByDescending(c => c.ServiceProviders.Count)
                .Take(count);
        }
    }

    public class ServiceRequestRepository : BaseRepository<ServiceRequest>
    {
        public ServiceRequestRepository(DelelContext context) : base(context) { }

        public IQueryable<ServiceRequest> GetActiveRequests(string clientId = null)
        {
            var query = GetList(x => !x.IsDeleted && x.Status == RequestStatus.Pending);

            if (!string.IsNullOrEmpty(clientId))
                query = query.Where(x => x.ClientId == clientId);

            return query.OrderByDescending(x => x.Date);
        }

        public IQueryable<ServiceRequest> GetRequestWithProposals(int requestId)
        {
            return GetList(x => x.Id == requestId);
        }
    }

    public class ServiceProviderPropsalRepository : BaseRepository<ServiceProviderPropsal>
    {
        public ServiceProviderPropsalRepository(DelelContext context) : base(context) { }

        public IQueryable<ServiceProviderPropsal> GetProviderProposals(string providerId)
        {
            return GetList(x => x.ServiceProviderId == providerId)
                .OrderByDescending(x => x.Status == ProposalStatus.Pending)
                .ThenBy(x => x.SuggestedPrice);
        }

        public void AcceptProposal(int proposalId)
        {
            var proposal = Table.Find(proposalId);
            if (proposal != null)
            {
                proposal.Status = ProposalStatus.Accepted;
                Update(proposal);
            }
        }
    }

    public class ServiceProviderScheduleRepository : BaseRepository<ServiceProviderSchedule>
    {
        public ServiceProviderScheduleRepository(DelelContext context) : base(context) { }

        public IQueryable<ServiceProviderSchedule> GetAvailableSchedules(string providerId, DateTime date)
        {
            var dayOfWeek = date.DayOfWeek;
            return GetList(x => x.ServiceProviderId == providerId &&
                               x.WorKDay == (WorKDays)dayOfWeek);
        }
    }

    public class ClientRepository : BaseRepository<Client>
    {
        public ClientRepository(DelelContext context) : base(context) { }

        public IQueryable<Client> GetClientWithRequests(string clientId)
        {
            return GetList(x => x.UserId == clientId);
        }
    }

    public class ServiceQuariesRepository : BaseRepository<ServiceQuaries>
    {
        public ServiceQuariesRepository(DelelContext context) : base(context) { }

        public IQueryable<ServiceQuaries> GetUnansweredQueries()
        {
            return GetList(x => string.IsNullOrEmpty(x.Answer))
                   .OrderBy(x => x.QuestionDate);
        }
    }

    public class ServiceProviderProjectRepository : BaseRepository<ServiceProviderProject>
    {
        public ServiceProviderProjectRepository(DelelContext context) : base(context) { }

        public IQueryable<ServiceProviderProject> GetFeaturedProjects(int count = 3)
        {
            return GetList()
                   .OrderByDescending(x => x.ServiceProvider.StartProfisionalAt)
                   .Take(count);
        }
    }
}