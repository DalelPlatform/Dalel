using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.Agency.AgencyPackage;
using Dalel.ViewModels.Agency.Packagebooking;
using Models.Agency;
using Models.Enums;
namespace Dalel.ViewModels
{
    public static class AgencyPackageExt
    {
        public static Models.Agency.AgencyPackage ToModel(this AddAgencyPackageVM packageVM)
        {
            return new AgencyPackage
            {
                Name = packageVM.Name,
                Price = packageVM.Price,
                Description = packageVM.Description,
                Duration =packageVM.Duration,
                TermsPolicies = packageVM.TermsPolicies,
                AgencyId = packageVM.AgencyId,
                VerificationStatus = Models.Enums.VerificationStatus.Pending,
                PackageSteps = packageVM.Steps.Select(i=>i.ToModel()).ToList(), 
                PackageSchadules = packageVM.Schadules.Select(i=>i.ToModel()).ToList(),
            };


        }
        public static AgencyPackageDetails ToDetailsModels(this AgencyPackage package)
        {
            return new AgencyPackageDetails
            {
                Id = package.Id,
                Price = package.Price,
                Name = package.Name,
                VerificationStatus= package.VerificationStatus ///???

            };
        }
        public static AgencyPackage ToEditModel(this AddAgencyPackageVM packageVM,
        AgencyPackage old)
        {

            old.Name = packageVM.Name;
            old.Price = packageVM.Price;
            old.Description = packageVM.Description;
            old.Duration = packageVM.Duration;
            old.TermsPolicies = packageVM.TermsPolicies;
            old.VerificationStatus = Models.Enums.VerificationStatus.Pending;
            return old;
        }
    }
    
}
