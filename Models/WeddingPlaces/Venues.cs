using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.WeddingPlaces
{
    class Venues
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public float Price { get; set; }
        public string AvaliabilityStatus { get; set; }
        public string OwnerId { get; set; } // fk PropertyOwners.userId

    }
}
