using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enums;
using Models;
namespace Dalel.ViewModels.Agency
{
    public class AgencyPromotionDetails
    {
        public int Id { get; set; }
        public float DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } //null untill owner deactive it
        public VerificationStatus status { get; set; }
        public int AgencyId { get; set; }
    }
}
