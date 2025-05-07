using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enums;

namespace Dalel.ViewModels
{
    public class ServiceProviderDetailsVM
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int CategoryServicesId { get; set; }
        public string CategoryName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public double AverageRating { get; set; }
        public int ProjectCount { get; set; }
        public int ScheduleCount { get; set; }
        public int ProposalCount { get; set; }
        public VerificationStatus VerificationStatus { get; set; }
    }
}
