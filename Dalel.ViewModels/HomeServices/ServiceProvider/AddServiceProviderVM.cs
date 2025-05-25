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
       
        public string UserId { get; set; }
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }
        public string Country { get; set; }
        public string District { get; set; }
        public string ServiceArea { get; set; }
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Price unit is required.")]
        public string PriceUnit { get; set; }

        public string About { get; set; }
        public string Website { get; set; }
        [Required(ErrorMessage = "Category number is required.")]
        public int CategoryServicesId { get; set; }
        public List<AddServiceProviderScheduleItemVM> Schedules { get; set; }
        public IFormFile? Image { get; set; }
    }
}
