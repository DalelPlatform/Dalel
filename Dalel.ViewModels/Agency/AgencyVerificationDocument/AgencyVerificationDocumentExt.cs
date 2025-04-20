using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dalel.ViewModels.Agency.AgencyPackage;
using Dalel.ViewModels.Agency.AgencyVerificationDocument;
using Dalel.ViewModels.Agency.Packagebooking;
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
               AgencyId=Document.AgencyId,

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
        public static AgencyVerificationDocument ToEditModel(this addAgencyVerificationDocumentVM doc,
        AgencyVerificationDocument old)
        {

            old.DocumentType = doc.DocumentType;
            old.DocumentFile = doc.DocumentFile;
            old.status = doc.status;
            return old;
        }
    }
}
