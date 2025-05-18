using Microsoft.AspNetCore.Http;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class AddPropertiesVM
    {
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Amenities are required.")]
        [StringLength(300, MinimumLength = 5, ErrorMessage = "Amenities must be between 5 and 300 characters.")]
        public string Amenities { get; set; }

        [Required(ErrorMessage = "Number of rooms is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Rooms must be at least 1.")]
        public int NumberOfRooms { get; set; }

        [Required(ErrorMessage = "Building number is required.")]
        public int BuildingNo { get; set; }

        [Required(ErrorMessage = "Floor number is required.")]
        public int FloorNo { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 250 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "City must be between 2 and 100 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Region is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Region must be between 2 and 100 characters.")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Street is required.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Street must be between 2 and 150 characters.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Latitude is required.")]
        public float Latitude { get; set; }

        [Required(ErrorMessage = "Longitude is required.")]
        public float Longitude { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Phone number is not valid.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Cancelation options must be selected.")]
        public bool CancelationOptions { get; set; }

        [Required(ErrorMessage = "Please select whether the property is for rent.")]
        public bool IsForRent { get; set; }

        [Required(ErrorMessage = "Verification status is required.")]
        public VerificationStatus VerificationStatus { get; set; }

        [Required(ErrorMessage = "Cancelation charges are required.")]
        [Range(0, float.MaxValue, ErrorMessage = "Cancelation charges must be 0 or greater.")]
        public float CancelationCharges { get; set; }

        public List<string> Paths { get; set; } = new();
        public IFormFileCollection? PropertyImages { get; set; }
        public string? OwnerId { get; set; }
    }

}
