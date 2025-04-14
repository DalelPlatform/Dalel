using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Agency;
using Models;
using Dalel.ViewModels.Agency.TravelAgencies;

namespace Dalel.Repository.Agency
{
    public class TravelAgenciesRepo : BaseRepository<TravelAgencies>
    {
            public TravelAgenciesRepo(DelelContext _delelContext) :
                base(_delelContext)
            {

            }
       
      

    }
    
}
