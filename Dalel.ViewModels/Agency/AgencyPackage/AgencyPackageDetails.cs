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
        public float Price { get; set; }

        public float Duration { get; set; }
        public string TermsPolicies { get; set; }

        public string Description { get; set; }
        public int AgencyId { get; set; }
        public string? ImagePath { get; set; }
        public virtual VerificationStatus VerificationStatus { get; set; }
        public List<PackageStepDetails> Steps { get; set; }
        public List<PackageSchaduleDetails> Schadules { get; set; }
    }
}
