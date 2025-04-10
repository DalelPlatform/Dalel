using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Models.Enums;

namespace Dalel.ViewModels.HomeChef.HomeChefMeal
{
    public class AddHomeChefMealVM
    {

        [Required(ErrorMessage = "Home Chef ID is required.")]
        public string HomeChefId { get; set; }

        [Required(ErrorMessage = "Dish Name is required.")]
        [StringLength(100, ErrorMessage = "Dish Name can't be longer than 100 characters.")]
        public string DishName { get; set; }

        [StringLength(500, ErrorMessage = "Description can't be longer than 500 characters.")]
        public string? Description { get; set; }

        [Range(0.01, 10000, ErrorMessage = "Price must be between 0.01 and 10,000.")]
        public decimal Price { get; set; }

        public bool AvailabilityStatus { get; set; }

        [Required(ErrorMessage = "Dietary Tags are required.")]
        [StringLength(200, ErrorMessage = "Dietary Tags can't be longer than 200 characters.")]
        public string DietaryTags { get; set; }

        [Required(ErrorMessage = "Food Category is required.")]
        public FoodCategory FoodCategory { get; set; }

        [Required(ErrorMessage = "Piece Size is required.")]
        public SizeOfPiece PieceSize { get; set; }

        [Range(1, 1440, ErrorMessage = "Duration must be between 1 and 1440 minutes.")]
        public double? Duration { get; set; }

        public List<string> Paths { get; set; } = new List<string>();
        public IFormFileCollection RestaurantMenuItemImages { get; set; }

    }
}
