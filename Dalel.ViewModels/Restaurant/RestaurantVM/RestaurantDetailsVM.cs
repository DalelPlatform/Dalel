using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enums;

namespace Dalel.ViewModels
{
    public class RestaurantDetailsVM
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public int NumberOfRooms { get; set; }

        public int BuildingNo { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string Street { get; set; }
        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public string PhoneNumber { get; set; }

        public VerificationStatus VerificationStatus { get; set; } //int 

        public string OwnerId { get; set; } //fk

        public List<string> Images { get; set; }
    }
}
