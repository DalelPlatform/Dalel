using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enums;
using Models;
namespace Dalel.ViewModels
{
    public class AgencyCustomerInquiryDetails
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Response { get; set; }
        public DateTime Date { get; set; }
    }
}
