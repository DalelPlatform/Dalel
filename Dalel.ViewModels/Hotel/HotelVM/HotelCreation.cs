using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Dalel.ViewModels
{
    public class HotelCreation
    {
        [Required(ErrorMessage = "Please provide a valid Hotel name.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Hotel name must be between 3 and 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide a valid description.")]
        [StringLength(500, MinimumLength = 20, ErrorMessage = "Description must be between 20 and 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "City name must be at least 2 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Street is required.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Street must be at least 2 characters.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 250 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Latitude is required.")]
        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90.")]
        public float Latitude { get; set; }

        [Required(ErrorMessage = "Longitude is required.")]
        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180.")]
        public float Longitude { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        public bool CancelationOptions { get; set; }

        [Required(ErrorMessage = "Cancelation charges are required.")]
        public float CancelationCharges { get; set; }

        public string? OwnerId { get; set; }

        // For uploading images: list of image paths or names (this collection can be populated after file saving)
        public List<string> Paths { get; set; } = new List<string>();

        // Files uploaded for the hotel images.
        public IFormFileCollection? HotelImage { get; set; }
    }
}
