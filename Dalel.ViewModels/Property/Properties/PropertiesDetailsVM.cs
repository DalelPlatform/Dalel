using Models.Enums;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class PropertiesDetailsVM
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Amenities { get; set; }
        public int NumberOfRooms { get; set; }
        public float PricePerNight { get; set; }
        public int BuildingNo { get; set; }
        public int FloorNo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsForRent { get; set; }
        public  string PropertyOwner { get; set; }
        public VerificationStatus VerificationStatus { get; set; }
        public List<string> Images { get; set; }
    }
}
