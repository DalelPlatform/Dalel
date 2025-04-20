using Models.Hotel;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.Hotel.HotelVM; // Make sure this namespace matches where you defined DateGreaterThanAttribute

namespace Dalel.ViewModels.Hotel.HotelVM
{
    public class HotelSearchRequest
    {
        [Required(ErrorMessage = "City is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "City must be between 2-100 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "Check-in date is required")]
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage = "Check-out date is required")]
        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Minimum price must be at least 0.01")]
        public decimal? MinPrice { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Maximum price must be at least 0.01")]
        public decimal? MaxPrice { get; set; }

        public List<Service> services { get; set; } = new List<Service>();

        [RegularExpression("price_asc|price_desc|rating",
            ErrorMessage = "Invalid sort option. Use 'price_asc', 'price_desc', or 'rating'")]
        public string SortBy { get; set; }
    }
}