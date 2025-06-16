using Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.HomeServices.ServiceProviderSchedule
{
    public class AddServiceProviderScheduleItemVM
    {
        [Required(ErrorMessage = "Available from time is required.")]
        public TimeOnly AvailableFrom { get; set; }

        [Required(ErrorMessage = "Available to time is required.")]
        public TimeOnly AvailableTo { get; set; }
        public WorKDays WorKDay { get; set; }
    }
}
    
    

