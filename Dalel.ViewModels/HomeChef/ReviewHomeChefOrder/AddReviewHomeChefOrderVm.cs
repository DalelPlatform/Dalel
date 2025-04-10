using System;
using System.ComponentModel.DataAnnotations;

namespace Dalel.ViewModels
{
    public class AddReviewHomeChefOrderVM
    {
        [Required(ErrorMessage = "Comments are required.")]
        [StringLength(1000, ErrorMessage = "Comments can't be longer than 1000 characters.")]
        public string Comments { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public float Rating { get; set; }

        public DateTime ModificationDateTime { get; set; } = DateTime.Now; // Default to current time

        public int? HomeChefOrderId { get; set; } // Make HomeChefOrderId optional
    }
}
