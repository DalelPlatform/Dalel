using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enums;
using Models;
using Dalel.ViewModels.Agency.PackageSchadule;
using Dalel.ViewModels.Agency.PackageStep;
namespace Dalel.ViewModels.Agency.AgencyPackage
{
    public class AgencyPackageDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int AgencyId { get; set; }
        public virtual VerificationStatus VerificationStatus { get; set; }
        public List<addPackageStepVM> Steps { get; set; }
        public List<addPackageSchaduleVM> Schadules { get; set; }
    }
}
