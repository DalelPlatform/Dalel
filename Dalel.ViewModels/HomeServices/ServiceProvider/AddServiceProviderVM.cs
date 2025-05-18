using Dalel.ViewModels.HomeServices.ServiceProviderSchedule;
using Microsoft.AspNetCore.Http;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.HomeServices.ServiceProvider
{
    public class AddServiceProviderVM
    {
        [Required(ErrorMessage = "User ID is required.")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Price unit is required.")]
        public string PriceUnit { get; set; }

        public string About { get; set; }
        public string Website { get; set; }
        public int CategoryServicesId { get; set; }
        public VerificationStatus? VerificationStatus { get; set; }
        public List<AddServiceProviderScheduleItemVM> Schedules { get; set; }
        public IFormFile? Image { get; set; }
    }
}
