using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Enums;

namespace Dalel.Repository.Agency
{
    public class AgencyPackage : BaseRepository<AgencyPackage>
    {
        //Get Packages by Agency ID
        private DelelContext delelContext;

        public AgencyPackage (DelelContext _delelContext) : 
            base(_delelContext)
        {
           
            delelContext = _delelContext;
           
        }
        public IQueryable<AgencyPackage> getAgencyPackage(int pckg_id)
        {
            return delelContext.AgencyPackages
                .Where(agenc => agenc.AgencyId == pckg_id);

        }
        //Search Packages by Name
        public async Task<IQueryable<AgencyPackage>> searchAgencyPackage(string pckg_name)
        {
            return await delelContext.AgencyPackages
                .Select(agenc => agenc.Name.Contains(pckg_name)).ToList();

        }
        //Get Verified Packages
        public async Task<IQueryable<AgencyPackage>> GetVerifiedPackages()
        {
            return await delelContext.AgencyPackages
                .Select(agenc => agenc.VerificationStatus ==
                VerificationStatus.Confirmed).ToList();

        }
        //Get Cheapest Packages
        public Task<IQueryable<AgencyPackage>> GetCheapestPackages()
        {
            return delelContext.AgencyPackages
                .OrderBy(p => Convert.ToDecimal(p.Price))
                .Take(5).ToList();
                ;

        }

    }
}