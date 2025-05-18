using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enums;

namespace Dalel.ViewModels.Agency.AgencyVerificationDocument
{
    public class AgencyVerificationDocumentDetails
    {
        public int Id { get; set; }
        public string DocumentType { get; set; }
        public string DocumentFile { get; set; }
        public virtual VerificationStatus status { get; set; }
    }
}
