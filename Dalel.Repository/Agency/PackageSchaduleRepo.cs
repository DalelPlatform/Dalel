using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Agency;
using Models;

namespace Dalel.Repository.Agency
{
    public class PackageSchaduleRepo : BaseRepository<PackageSchadule>
    {
        public PackageSchaduleRepo(DelelContext _delelContext) :
            base(_delelContext)
        {

        }
    }
}
