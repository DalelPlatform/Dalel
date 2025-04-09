using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.Agency.AgencyCustomerInquiry;
using Models.Agency;
namespace Dalel.ViewModels
{
    public static class AgencyCustomerInquiryExt
    {
        public static Models.Agency.AgencyCustomerInquiry ToModel(this AddAgencyCustomerInquiryVM packageVM)
        {
            return new AgencyCustomerInquiry
            {
               Message = packageVM.Message,
               Response = packageVM.Response,
               Date = packageVM.Date,


            };


        }
        public static AgencyCustomerInquiryDetails ToDetailsModels(this AgencyCustomerInquiry package)
        {
            return new AgencyCustomerInquiryDetails
            {
                Id = package.Id,
                Message = package.Message,
                Response=package.Response,
                Date=package.Date,

            };
        }
    }
    
}
