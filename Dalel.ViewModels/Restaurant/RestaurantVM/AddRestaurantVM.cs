using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Models.Enums;

namespace Dalel.ViewModels.Restaurant.RestaurantVM
{
    public class AddRestaurantVM
    {
        [Required(ErrorMessage = "Please Provide valid Restaurant Name")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Item name must contain at least 3 letter and max 100 letter")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please provide a valid description.")]
        [StringLength(200, MinimumLength = 20, ErrorMessage = "Description must be between 20 and 200 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Number of rooms is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of rooms must be greater than 0.")]
        public int NumberOfRooms { get; set; }

        [Required(ErrorMessage = "Building number is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Building number must be a positive number.")]
        public int BuildingNo { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 250 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "City name must be at least 2 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Region is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Region name must be at least 2 characters.")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Street is required.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Street name must be at least 2 characters.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Latitude is required.")]
        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90.")]
        public float Latitude { get; set; }

        [Required(ErrorMessage = "Longitude is required.")]
        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180.")]
        public float Longitude { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        [StringLength(15, MinimumLength = 7, ErrorMessage = "Phone number must be between 7 and 15 digits.")]
        public string PhoneNumber { get; set; }




        public List<string> Paths { get; set; } = new List<string>();
        public IFormFileCollection RestaurantImage { get; set; }
    }
}

