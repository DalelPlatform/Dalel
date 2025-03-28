using Models.Enums;
using Models.HomeService;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Repository
{
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
}
