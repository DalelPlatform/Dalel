using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.User;

namespace Models.Agency
{
    public class TravelAgencyOwners
    {
        public int Id { get; set; }
        public string UserId { get; set; } // fk & pk
        public virtual AppUser AppUser { get; set; }
        public ICollection <TravelAgencies> TravelAgencies { get; set; }
        public ICollection<Agency_CustomerInquiry> Inquiry { get; set; }
    }
}
