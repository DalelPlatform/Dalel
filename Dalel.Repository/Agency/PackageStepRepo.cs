using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Agency;
using Models;

namespace Dalel.Repository.Agency
{
    public class PackageStepRepo
    : BaseRepository<PackageStep>
    {
        public PackageStepRepo(DelelContext _delelContext) :
            base(_delelContext)
        {

        }
        public IQueryable<PackageStep> GetStepsByPackageId(int packageId)
        {
            return  base.GetList()
                .Where(step => step.PackageId == packageId);
             
        }
       
    }
}
