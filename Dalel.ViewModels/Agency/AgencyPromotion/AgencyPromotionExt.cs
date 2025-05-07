using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.Agency;
using Dalel.ViewModels.Agency.AgencyPackage;
using Models.Agency;
namespace Dalel.ViewModels
{
    public static class AgencyPromotionExt
    {
        public static Models.Agency.AgencyPromotion ToModel(this AddAgencyPromotionVM promote)
        {
            return new AgencyPromotion
            {
                DiscountPercentage = promote.DiscountPercentage,
                StartDate = promote.StartDate,
                EndDate = promote.EndDate,
                status = promote.status,
                AgencyId = promote.AgencyId,
            };


        }
        public static AgencyPromotionDetails ToDetailsModels(this AgencyPromotion promote)
        {
            return new AgencyPromotionDetails
            {
                Id = promote.Id,
                DiscountPercentage = promote.DiscountPercentage,
                StartDate = promote.StartDate,
                EndDate = promote.EndDate,
                status = promote.status,
                AgencyId = promote.AgencyId,

            };
        }
    }

}