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
        public string Country { get; set; }
        public string ServiceArea { get; set; }
        public string ZipCode { get; set; }
        public string District { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public decimal? Price { get; set; }
        public string PriceUnit { get; set; }
        public string About { get; set; }
        public string Website { get; set; }

        public int CategoryServicesId { get; set; }
        public List<ServiceProviderScheduleDetailsVM> Schedules { get; set; }
        public List<ServiceProviderProjectDetailsVM> Projects { get; set; }
        public string? Image { get; set; }
    }
}
