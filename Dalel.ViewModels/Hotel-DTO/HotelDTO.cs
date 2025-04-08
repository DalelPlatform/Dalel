using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.Hotel_DTO
{
    public class HotelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Address { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string PhoneNumber { get; set; }
        public bool CancelationOptions { get; set; }
        public float CancelationCharges { get; set; }
        public string VerificationStatus { get; set; } // Enum can be mapped to string for simplicity
        public bool IsDeleted { get; set; }
        public ICollection<HotelImageDTO> HotelImages { get; set; }
        public ICollection<RoomTypeDTO> RoomTypes { get; set; }
    }

}
