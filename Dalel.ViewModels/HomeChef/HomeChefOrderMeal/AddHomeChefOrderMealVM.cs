using System.ComponentModel.DataAnnotations;

namespace Dalel.ViewModels.HomeChef.HomeChefOrderMeal
{
    public class AddHomeChefOrderMealVM
    {
        [Range(0, 10000, ErrorMessage = "Supplementary Price must be between 0 and 10,000.")]
        public float SupPrice { get; set; }

        [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000.")]
        public float Quantity { get; set; }

        [Required(ErrorMessage = "Home Chef Order ID is required.")]
        public int HomeChefOrdersId { get; set; }

        [Required(ErrorMessage = "Home Chef Meal ID is required.")]
        public int HomeChefMealsId { get; set; }
    }
}

