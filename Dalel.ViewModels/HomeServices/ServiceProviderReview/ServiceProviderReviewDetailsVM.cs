using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class ServiceProviderReviewDetailsVM
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public string ServiceProviderId { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public DateTime ReviewDate { get; set; }
        public string ClientId { get;  set; }
    }
}
