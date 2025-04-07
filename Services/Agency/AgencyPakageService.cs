using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.Repository.Agency;
using Dalel.ViewModels.Agency.AgencyPackage;
using Models.Agency;
using Utilities;

namespace Dalel.Services.Agency
{
    public class AgencyPakageService
    {
        AgencyPackageRepo AgencyPackageRepo { get; set; }
        public AgencyPakageService(AgencyPackageRepo _AgencyPackageRepo)
        {
            AgencyPackageRepo = _AgencyPackageRepo;
        }
        public ServiceResult CreateAgencyPackage(AgencyPackage agency  )
        {
            AgencyPackageRepo.Add(agency);
            return new ServiceResult
            {
                Success = true,
                Message = "added successfully."
            };
        }
        public ServiceResult UpdateAgencyPackage(AgencyPackage agency)
        {
            AgencyPackageRepo.Update(agency);
            return new ServiceResult
            {
                Success = true,
                Message = "update successfully."
            };
        }
        public ServiceResult deleteAgencyPackage(int agencyId)
        {
            var _agencyPackage = AgencyPackageRepo.GetList(i => i.Id == agencyId).FirstOrDefault();
            if (_agencyPackage != null) {
                AgencyPackageRepo.Delete(_agencyPackage);
            }
            
            return new ServiceResult
            {
                Success = true,
                Message = "deleted successfully."
            };
        }
    }
}
