using System;
using System.ComponentModel.DataAnnotations;
using Models.Restaurant.Enums;

namespace Dalel.ViewModels.Restaurant
{
    public class AddRestaurantReservationVM
    {
        [MaxLength(500, ErrorMessage = "Comments can't be longer than 500 characters.")]
        public string? Comments { get; set; }

        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public float Rating { get; set; }

        [Required(ErrorMessage = "Modification date is required.")]
        public DateTime ModificationDateTime { get; set; }

        [MaxLength(10, ErrorMessage = "Table number can't be longer than 10 characters.")]
        public string? TableNumber { get; set; }

        [Required(ErrorMessage = "Reservation status is required.")]
        public StatusOfReservations ReervationStatus { get; set; }

        [Required(ErrorMessage = "Restaurant Id is required.")]
        public int RestaurantId { get; set; }

        
        public string ClientId { get; set; }
    }
}
