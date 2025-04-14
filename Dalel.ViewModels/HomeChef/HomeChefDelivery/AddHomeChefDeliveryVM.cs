using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Models.Enums;

namespace Dalel.ViewModels
{
    public class AddHomeChefDeliveryVM
    {
        [Required(ErrorMessage = "Platform Logistics is required.")]
        [StringLength(200, ErrorMessage = "Platform Logistics can't be longer than 200 characters.")]
        public string PlatformLogistics { get; set; }

        public bool SelfDelivery { get; set; }

        [Required(ErrorMessage = "Delivery Status is required.")]
        public StatusOfDelivery DeliveryStatus { get; set; }

        [Required(ErrorMessage = "Home Chef Order ID is required.")]
        public int HomeChefOrderId { get; set; }
    }
}

