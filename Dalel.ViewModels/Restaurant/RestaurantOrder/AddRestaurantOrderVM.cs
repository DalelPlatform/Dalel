using System;
using System.ComponentModel.DataAnnotations;
using Dalel.ViewModels.Restaurant;
using Models.Enums;

namespace Dalel.ViewModels
{
    public class AddRestaurantOrderVM
    {

        public DateTime Date { get; set; } = DateTime.Now ;

        //[Range(0.01, double.MaxValue, ErrorMessage = "TotalPrice must be greater than 0.")]
        //public float TotalPrice { get; set; }

        [Required]
        public OrderStatus OrderStatus { get; set; }

        [Required(ErrorMessage = "RestaurantId is required.")]
        public int RestaurantId { get; set; }

        [Required(ErrorMessage = "ClientId is required.")]
        public string ClientId { get; set; }

       public List<AddRestaurantOrderItemVM> listItems { get; set; } 
    }

   
}
