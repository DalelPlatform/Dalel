using System;
using System.ComponentModel.DataAnnotations;
using Models.Enums;

namespace Dalel.ViewModels.Restaurant
{
    public class AddRestaurantOrderVM
    {
        [Required]
        public DateTime Date { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "TotalPrice must be greater than 0.")]
        public float TotalPrice { get; set; }

        [Required]
        public OrderStatus OrderStatus { get; set; }

        [Required(ErrorMessage = "RestaurantId is required.")]
        public int RestaurantId { get; set; }

        [Required(ErrorMessage = "ClientId is required.")]
        public string ClientId { get; set; }
    }
}
