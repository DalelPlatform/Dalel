using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.HomeService
{
   public class ServiceProviderPropsal
    {
        public int Id { get; set; }
        public int ServiceProviderId { get; set; }
        public virtual ServiceProvider ServiceProvider { get; set; }

        public double SuggestedPrice { get; set; }
        public string Description { get; set; }
        public bool IsAccepted { get; set; } = false;

        public int ServiceRequestId { get; set; }
        public virtual ServiceRequest ServiceRequest { get; set; }
    }
}
