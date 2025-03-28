using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Agency;
using Models.Enums;

namespace Dalel.Repository.Agency
{
    public class APackage : BaseRepository<AgencyPackage>
    {
        //Get Packages by Agency ID
    
        public APackage (DelelContext _delelContext) : 
            base(_delelContext)
        {
           
        }
        public IQueryable<AgencyPackage> getAgencyPackage(int pckg_id)
        {
            return base.GetList(agenc => agenc.AgencyId == pckg_id);
               ;

        }
        //Search Packages by Name
        public  IQueryable<AgencyPackage> searchAgencyPackage(string pckg_name)
        {
            return base.GetList(agenc => agenc.Name.Contains(pckg_name));
                

        }
        //Get Verified Packages
        public  IQueryable<AgencyPackage> GetVerifiedStatusPackages(VerificationStatus status)
        {
            return base.GetList(agenc => agenc.VerificationStatus ==
                status);
             ;

        }
        //Get Cheapest Packages
        public IQueryable<AgencyPackage> GetCheapestPackages(int cheapPackg)
        {
            return base.GetList()
                .OrderBy(p => Convert.ToDecimal(p.Price))
                .Take(cheapPackg);
                ;

        }

    }
}