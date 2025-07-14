using System;
using System.ComponentModel.DataAnnotations;
using Dalel.ViewModels.Restaurant;
using Models.Enums;

namespace Dalel.ViewModels
{
    public class AddRestaurantOrderVM
    {
        public DateTime Date { get; set; } = DateTime.Now;

        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "TotalPrice must be greater than 0.")]
        public float TotalPrice { get; set; }

        //[Required(ErrorMessage = "RestaurantId is required.")]
        //public int RestaurantId { get; set; }

        public string? ClientId { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        public string? Note { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "Phone number must be a valid Egyptian mobile number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        //[Required(ErrorMessage = "At least one item is required.")]
        //public List<AddRestaurantOrderItemVM> ListItems { get; set; }
    }


}
