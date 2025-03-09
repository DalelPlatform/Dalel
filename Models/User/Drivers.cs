using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.User
{
    public class Drivers
    {
        public string UserId { get; set; } //fk & pk 
        public string LicenseNumber { get; set; }

        public bool Abailability { get; set; }

    }
}
