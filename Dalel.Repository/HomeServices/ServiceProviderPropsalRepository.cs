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
    public class ServiceProviderPropsalRepository : BaseRepository<ServiceProviderPropsal>
    {
        private readonly DelelContext _context;
        public ServiceProviderPropsalRepository(DelelContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ServiceProviderPropsal> GetProviderProposals(string providerId)
        {
            return GetList(x => x.ServiceProviderId == providerId)
                .OrderByDescending(x => x.Status == ProposalStatus.Pending)
                .ThenBy(x => x.SuggestedPrice);
        }

        public void AcceptProposal(int proposalId)
        {
            var proposal = base.GetList(i => i.Id == proposalId).FirstOrDefault();
            if (proposal != null)
            {
                proposal.Status = ProposalStatus.Accepted;
                Update(proposal);
            }
        }
    }
}
