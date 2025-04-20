using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enums;

namespace Dalel.ViewModels.Agency
{
    public class AddAgencyPromotionVM
    {
      

        [Required(ErrorMessage = "Please Provide DiscountPercentage")]
        public float DiscountPercentage { get; set; }
        [Required(ErrorMessage = "Please Provide StartDate")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Please Provide EndDate")]
        public DateTime? EndDate { get; set; } //null untill owner deactive it
        [Required(ErrorMessage = "Please Provide status")]
        public VerificationStatus status { get; set; }
        public int AgencyId { get; set; }


    }


}
