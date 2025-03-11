using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Agency
{
    public class AgencyPackage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Duration { get; set; }
        public string Price { get; set; }
        public string TermsPolicies { get; set; }
        public int AgencyId { get; set; }
        public TravelAgencies Agency { get; set; }
        public ICollection<PackageStep> PackageSteps { get; set; }
        public ICollection<PackageSchadule> PackageSchadules { get; set;

    }
}
