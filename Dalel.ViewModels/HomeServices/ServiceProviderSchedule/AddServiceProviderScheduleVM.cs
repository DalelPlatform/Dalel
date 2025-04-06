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
        [Required]
        public WorKDays WorkDay { get; set; }

        [Required]
        public TimeOnly AvailableFrom { get; set; }

        [Required]
        public TimeOnly AvailableTo { get; set; }
        public string ServiceProviderId { get; set; }

    }
}
