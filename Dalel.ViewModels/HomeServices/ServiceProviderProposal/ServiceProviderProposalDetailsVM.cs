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
        public string ProviderName { get; set; }
        public string ProviderImage { get; set; }
        public double SuggestedPrice { get; set; }
        public string Description { get; set; }
        public ProposalStatus Status { get; set; }
    }
}
