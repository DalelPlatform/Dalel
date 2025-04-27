using System;
using System.Collections.Generic;
using Models.Enums;

namespace Dalel.ViewModels
{
    public class HotelDetails
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
        public string OwnerId { get; set; }
        public VerificationStatus VerificationStatus { get; set; }
        public List<string> Images { get; set; }
    }
}
