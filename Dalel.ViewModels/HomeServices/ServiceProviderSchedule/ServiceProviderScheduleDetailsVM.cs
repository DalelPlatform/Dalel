using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class ServiceProviderScheduleDetailsVM
    {
        public int Id { get; set; }
        public string ServiceProviderId { get; set; }
        public string ServiceProviderName { get; set; }
        public WorKDays WorKDay { get; set; }
        public TimeOnly AvailableFrom { get; set; }
        public TimeOnly AvailableTo { get; set; }
    }
}
