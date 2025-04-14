using Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class AddBookingPropertiesVM
    {
        [Required(ErrorMessage = "Check-in date is required.")]
        public DateTime CheckIn { get; set; }

        [Required(ErrorMessage = "Check-out date is required.")]
        public DateTime CheckOut { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, float.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Booking status is required.")]
        public BookingStatus Status { get; set; }

        [Required(ErrorMessage = "PropertyId is required.")]
        public int PropertyId { get; set; }

        public string? ClientId { get; set; }
    }

}
