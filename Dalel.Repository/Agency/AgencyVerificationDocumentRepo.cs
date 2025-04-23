using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Agency;
using Models;
using Models.Enums;
using Dalel.ViewModels.Agency.AgencyVerificationDocument;
using Dalel.ViewModels;

namespace Dalel.Repository.Agency
{
    public class AgencyVerificationDocumentRepo :
    BaseRepository<AgencyVerificationDocument>
    {
        //Get Packages by Agency ID

        public AgencyVerificationDocumentRepo(DelelContext _delelContext) :
            base(_delelContext)
        {

        }
        //Get Verification Documents
        public IQueryable<AgencyVerificationDocumentDetails>
            GetVerificationDocuments(int agencyId)
        {
            return base.GetList(doc => doc.AgencyId == agencyId)
                .Select(doc => doc.ToDetailsModels())
                ;
        }
        //documents awaiting approval
        public IQueryable<AgencyVerificationDocumentDetails> GetPendingDocuments()
        {
            return GetList(p => p.status == VerificationStatus.Pending)
                .Select(doc => doc.ToDetailsModels());

        }
        public bool UpdateDocumentStatus(int documentId, VerificationStatus newStatus)
        {
            var document = base.GetList(doc => doc.Id == documentId).FirstOrDefault();
            if (document == null)
                return false;

            document.status = newStatus;
            base.Update(document);
            return true;
        }
        //Upload a New Verification Document
        public bool AddVerificationDocument(int agencyId, string documentType, string documentFile)
        {
            var document = new AgencyVerificationDocument
            {
                AgencyId = agencyId,
                DocumentType = documentType,
                DocumentFile = documentFile,
                status = VerificationStatus.Pending

            };
            base.Add(document);
            return true;
        }

        //Get Approved Documents for an Agency
        public IQueryable<AgencyVerificationDocumentDetails>
            GetApprovedDocuments(int agencyId)
        {
            return GetList(approve => approve.AgencyId == agencyId && approve.status ==
            VerificationStatus.Confirmed
            ).Select(doc => doc.ToDetailsModels());
        }
    }
}