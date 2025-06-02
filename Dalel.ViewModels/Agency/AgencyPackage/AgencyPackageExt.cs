using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.Agency.AgencyPackage;
using Dalel.ViewModels.Agency.Packagebooking;
using Dalel.ViewModels.Agency.PackageSchadule;
using Dalel.ViewModels.Agency.PackageStep;
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
                Duration = packageVM.Duration,
                TermsPolicies = packageVM.TermsPolicies,
                AgencyId = packageVM.AgencyId,
                VerificationStatus = Models.Enums.VerificationStatus.Pending,
                PackageSteps = packageVM.Steps.Select(i => i.ToModel()).ToList(),
                PackageSchadules = packageVM.Schadules.Select(i => i.ToModel()).ToList(),
                
            };


        }
        public static AgencyPackageDetails ToDetailsModels(this AgencyPackage package)
        {
            return new AgencyPackageDetails
            {
                Id = package.Id,
                Price = package.Price,
                Name = package.Name,
                AgencyId = package.AgencyId,
                VerificationStatus = package.VerificationStatus, ///???
                Steps = package.PackageSteps.Select(s => new addPackageStepVM
                {
                    Name = s.Name,
                    Description = s.Description,
                    Duration = s.Duration,
                    Image = s.Image
                }).ToList(),
                Schadules = package.PackageSchadules.Select(s => new addPackageSchaduleVM
                {
                    Date = s.Date,
                    SlotsAvailable = s.SlotsAvailable
                }).ToList()

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