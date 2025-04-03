using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.Agency.AgencyPackage
{
    public class AddAgencyPaymentVM
    {
        [Required(ErrorMessage = "Please Provide valid Agency Name")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Agency name must contain at least 3 letter and max 100 letter")]
        public string Name { get; set; }

        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Agency Description must contain at least 10 letter and max 1000 letter")]
      
        public string Description { get; set; }




        [Required(ErrorMessage = "Please Provide valid Agency Price Start from 5")]
     
        public string Price { get; set; }




    }
}
