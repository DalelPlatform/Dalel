using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.HomeServices.ServiceProviderSchedule
{
    public class ServiceProviderScheduleDetailsVM
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public string AvailableFrom { get; set; }
        public string AvailableTo { get; set; }
        public string ProviderName { get; set; }
    }
}
