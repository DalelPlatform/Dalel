using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Models.Enums;

namespace Dalel.ViewModels
{
    public class AddHomeChefOrderVM
    {
        [Required(ErrorMessage = "Order Date is required.")]
        public DateTime OrderDate { get; set; }

        [Range(0.01, 100000, ErrorMessage = "Total Price must be between 0.01 and 100,000.")]
        public float TotalPrice { get; set; }

        [Required(ErrorMessage = "Order Status is required.")]
        public OrderStatus OrderStatus { get; set; }

        [Required(ErrorMessage = "Home Chef ID is required.")]
        public string HomeChefId { get; set; }

        [Required(ErrorMessage = "Client ID is required.")]
        public string ClientId { get; set; }
    }
}

