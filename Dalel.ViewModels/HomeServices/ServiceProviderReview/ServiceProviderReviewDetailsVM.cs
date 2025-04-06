using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.HomeServices.ServiceProviderReview
{
    public class ServiceProviderReviewDetailsVM
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
        public string ReviewDate { get; set; }
    }
}
