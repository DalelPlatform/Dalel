using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.Agency.AgencyPackage;
using Dalel.ViewModels.Agency.AgencyVerificationDocument;
using Models.Agency;

namespace Dalel.ViewModels
{
    public static class AgencyVerificationDocumentExt
    {
        public static AgencyVerificationDocument ToModel(this addAgencyVerificationDocumentVM Document)
        {
            return new AgencyVerificationDocument
            {
               DocumentFile=Document.DocumentFile,
               DocumentType=Document.DocumentType,
               status = Document.status,


            };


        }
        public static AgencyVerificationDocumentDetails ToDetailsModels(this
            AgencyVerificationDocument doc)
        {
            return new AgencyVerificationDocumentDetails
            {
                Id=doc.Id,
                DocumentType = doc.DocumentType,
                DocumentFile = doc.DocumentFile,
                status = doc.status

            };
        }
    }
}
