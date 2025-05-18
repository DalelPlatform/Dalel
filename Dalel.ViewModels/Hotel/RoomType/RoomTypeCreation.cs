using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models.Enums;  

namespace Dalel.ViewModels
{
    public class RoomTypeCreation
    {
        [Required(ErrorMessage = "Room type is required.")]
        [EnumDataType(typeof(HotelRoomType), ErrorMessage = "Invalid room type.")]
        public HotelRoomType Type { get; set; }

        [Required(ErrorMessage = "Max occupancy is required.")]
        [Range(1, 20, ErrorMessage = "Max occupancy must be between 1 and 20.")]
        public int MaxOccupancy { get; set; }

        [Required(ErrorMessage = "Breakfast option must be specified.")]
        public bool HasBreakfast { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(250, ErrorMessage = "Description cannot exceed 250 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Number of rooms is required.")]
        [Range(1, 100, ErrorMessage = "There must be at least one room.")]
        public int NumberOfRooms { get; set; }

        [Required(ErrorMessage = "Number of beds is required.")]
        [Range(1, 10, ErrorMessage = "There must be at least one bed.")]
        public int NumberOfBeds { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Price must be a non‑negative number.")]
        public float Price { get; set; }

        [Required(ErrorMessage = "HotelId is required.")]
        public int HotelId { get; set; }

        public List<string>? RoomTypeImages { get; set; }  // base64 or URLs
    }
}
