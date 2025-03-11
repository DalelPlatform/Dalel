using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Agency.Enums;

namespace Models.Agency
{
    public class PackageSchadule
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int SlotsAvailable { get; set; }
        public VerificationStatus Status { get; set; }
        public int PackageId { get; set; }
        public AgencyPackage AgencyPackage { get; set; }

        public ICollection <PackageBooking> PabckageBookings { get; set; }

    }
}
