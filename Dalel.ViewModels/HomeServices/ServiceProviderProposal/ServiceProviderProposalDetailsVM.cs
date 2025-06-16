using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class ServiceProviderProposalDetailsVM
    {
        public int Id { get; set; }
        public string ServiceProviderId { get; set; }
        public int ServiceRequestId { get; set; }
        public string Description { get; set; }
        public double SuggestedPrice { get; set; }
        public string ServiceProviderName { get; set; }
        public DateTime? Date { get; set; }
        public ProposalStatus Status { get; set; }

    }
}
