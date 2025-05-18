using System.ComponentModel.DataAnnotations;

namespace Dalel.ViewModels.Restaurant
{
    public class AddRestaurantOrderItemVM
    {
        [Required(ErrorMessage = "Supplement price is required.")]
        [Range(0, float.MaxValue, ErrorMessage = "SupPrice must be a positive number.")]
        public float SupPrice { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, float.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public float Quantity { get; set; }

        [Required(ErrorMessage = "Menu Item Id is required.")]
        public int RestaurantMenuItemId { get; set; }

        [Required(ErrorMessage = "Oreder Menu Id is required.")]
        public int RestaurantOrderId { get; set; }
    }
}


