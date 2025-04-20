using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enums;

namespace Dalel.ViewModels.Agency.AgencyVerificationDocument
{
    public class addAgencyVerificationDocumentVM
    {
        [Required(ErrorMessage = "Please Provide valid DocumentType")]
        public string DocumentType { get; set; }
        [Required(ErrorMessage = "Please Provide valid DocumentFile")]
        public string DocumentFile { get; set; }

        [Required(ErrorMessage = "Please Select stutus")]
        public virtual VerificationStatus status { get; set; }
        public int AgencyId { get; set; }
    }
}
