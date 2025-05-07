using Dalel.ViewModels.HomeServices.ServiceProviderSchedule;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class AddServiceProviderScheduleVM
    {
        [Required(ErrorMessage = "Service provider ID is required.")]
        public string ServiceProviderId { get; set; }

        [Required(ErrorMessage = "At least one schedule is required.")]
        public List<AddServiceProviderScheduleItemVM> Schedules { get; set; }

    }
}
