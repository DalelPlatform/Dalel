using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.Agency.AgencyCustomerInquiry
{
    public class AddAgencyCustomerInquiryVM
    {
        [Required(ErrorMessage = "Please Provide Message")]
     public string Message { get; set; }

      [Required(ErrorMessage = "Please Provide Response")]
        public string Response { get; set; }




        [Required(ErrorMessage = "Please Provide valid Date")]
     
        public DateTime Date { get; set; }




    }
}
