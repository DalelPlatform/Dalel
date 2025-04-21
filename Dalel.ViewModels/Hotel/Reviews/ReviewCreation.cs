using System;
using System.ComponentModel.DataAnnotations;

namespace Dalel.ViewModels.Hotel
{
    public class ReviewCreation
    {
        [Required(ErrorMessage = "Comments are required.")]
        [StringLength(1000, ErrorMessage = "Comments cannot exceed 1000 characters.")]
        public string Comments { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public float Rating { get; set; }

        [Required(ErrorMessage = "Review date is required.")]
        public DateTime ReviewDate { get; set; }

        [Required(ErrorMessage = "BookingHotelRoomId is required.")]
        public int BookingHotelRoomId { get; set; }

        [Required(ErrorMessage = "ClientId is required.")]
        public int ClientId { get; set; }
    }
}
