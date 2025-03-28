using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enums;
using Models;
namespace Dalel.ViewModels.Agency.AgencyPackage
{
    public class AgencyPaymentDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int AgencyId { get; set; }
        public virtual VerificationStatus VerificationStatus { get; set; }
    }
}
