using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Agency;

namespace Dalel.Repository.Agency
{
    public class AgencyPromotionRepo : BaseRepository<AgencyPromotion>
    {
        public AgencyPromotionRepo(DelelContext _delelContext) :
            base(_delelContext)
        {

        }
        //Get active promotions for a specific agency
        public IQueryable<AgencyPromotion> GetActivePromotions(int agencyId)
        {
            return GetList(p => p.AgencyId == agencyId &&
            (p.EndDate == null || p.EndDate > DateTime.Now)); //still active or in future 
        }
    }
}
