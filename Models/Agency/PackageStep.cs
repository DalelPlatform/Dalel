using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Agency
{
    public class PackageStep
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Duration { get; set; }
        public string Image { get; set; }
        public int PackageId { get; set; }
        public AgencyPackage AgencyPackage { get; set; }
    }
}
