using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.Agency.AgencyPackage;
using Models.Agency;
namespace Dalel.ViewModels
{
    public static class AgencyPackageExt
    {
        public static AgencyPackage ToModel(this AgencyPackageDetails packageVM)
        {
            return new AgencyPackage
            {
                Name = packageVM.Name,
                Price = packageVM.Price,
                AgencyId = packageVM.AgencyId,
                VerificationStatus = packageVM.VerificationStatus


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
    }
    
}
