using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Dalel.ViewModels.Agency.AgencyPackage;
using Dalel.ViewModels.Agency.Packagebooking;
using Models.Agency;
using static System.Runtime.InteropServices.JavaScript.JSType;
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
        public static AgencyCustomerInquiry ToEditModel(this AddAgencyCustomerInquiryVM packageVM,
        AgencyCustomerInquiry old)
        {
            old.Message = packageVM.Message;
            old.Response = packageVM.Response;
            old.Date = packageVM.Date;
            return old;
        }
    }
    
}
