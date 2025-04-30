using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels;
using Dalel.ViewModels.Agency;
using Models;
using Models.Agency;
using Models.Enums;

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
        public IQueryable<AgencyPromotionDetails> GetPendingPromotion()
        {
            return GetList(p => p.status == VerificationStatus.Pending)
                .Select(p => p.ToDetailsModels());

        }
        public bool UpdatePromotionStatus(int PromotionId, VerificationStatus newStatus)
        {
            var Promotion = base.GetList(p => p.Id == PromotionId).FirstOrDefault();
            if (Promotion == null)
                return false;

            Promotion.status = newStatus;
            base.Update(Promotion);
            return true;
        }
    }
}
