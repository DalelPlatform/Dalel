using System;
using System.Collections.Generic;
using Models.Enums;
using Models.Restaurant;

namespace Dalel.ViewModels.Restaurant
{
    public class RestaurantOrderDetailsVM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string ClientId { get; set; }

        // Optional: Include nested details if needed
        public string? ClientName { get; set; }

        public List<RestaurantOrderItemDetailsVM>? OrderItems { get; set; }
        public ReviewRestaurantOrderDetailsVM? Review { get; set; }
        public PaymentRestaurantOrderDetailsVM? Payment { get; set; }
    }
}
