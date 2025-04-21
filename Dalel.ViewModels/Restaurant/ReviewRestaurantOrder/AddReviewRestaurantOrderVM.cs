using System;
using System.ComponentModel.DataAnnotations;

namespace Dalel.ViewModels.Restaurant
{
    public class AddReviewRestaurantOrderVM
    {
        [MaxLength(500, ErrorMessage = "Comments can't be longer than 500 characters.")]
        public string? Comments { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public float Rating { get; set; }

        [Required(ErrorMessage = "Modification date is required.")]
        public DateTime ModificationDateTime { get; set; }

        [Required(ErrorMessage = "RestaurantOrderId is required.")]
        public int RestaurantOrderId { get; set; }
    }
}
