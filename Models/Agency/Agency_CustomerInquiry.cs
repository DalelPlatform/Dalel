using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Driver;

namespace Models.Agency
{
    public class Agency_CustomerInquiry
    {
        public int Id { get; set; }
        public string Message { get; set; }

   public string Response { get; set; }
   public DateTime date { get; set; }
        public int AgencyId { get; set; }
        public TravelAgencyOwners AgencyOwners { get; set; }
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
