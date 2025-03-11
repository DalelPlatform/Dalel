using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Agency.Enums;

namespace Models.Agency
{
    public class AgencyVerificationDocument
    {
        public int Id { get; set; }
        public string DocumentType { get; set; }

        public string DocumentFile { get; set; }

        public VerificationStatus status { get; set; }
        public int AgencyId { get; set; }
        public TravelAgencies Agency { get; set; }

    }
}
