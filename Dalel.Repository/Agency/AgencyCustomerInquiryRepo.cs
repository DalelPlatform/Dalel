using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Resource;
using Dalel.ViewModels;
using Models;
using Models.Agency;

namespace Dalel.Repository.Agency
{
    public class AgencyCustomerInquiryRepo:
    BaseRepository<AgencyCustomerInquiry>
    {
       

        public AgencyCustomerInquiryRepo(DelelContext _delelContext) :
            base(_delelContext)
        {

        }
        //customer inquiries
        public IQueryable<AgencyCustomerInquiryDetails> GetagencyCustomerInquiries(string agencyId)
        {
            return GetList(cus =>cus.AgencyId == agencyId)
                .OrderByDescending(cus =>cus.Date).Select(i => i.ToDetailsModels());
        }

        //Get Inquiries for a Specific Client 
        public IQueryable<AgencyCustomerInquiryDetails> GetInquiryClient(string clientId)
        {
            return GetList(c=>c.ClientId == clientId)
                 .OrderByDescending(c => c.Date).Select(i => i.ToDetailsModels());
        }
        //Submit a New Customer Inquiry
        public bool SubmitInquiry(string clientId, string agencyId, string message)
        {
            var inquery = new AgencyCustomerInquiry
            {
                AgencyId = agencyId,
                ClientId = clientId,
                Message = message,
                Date = DateTime.UtcNow
            };
            base.Add(inquery);
            return true;
        }

    }   
}


