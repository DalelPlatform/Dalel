using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.Repository;
using Dalel.Repository.Agency;
using Models.Agency;
using Models.Enums;

namespace Dalel.Services
{
    public class PendingRequestService
    {
        private BaseRepository<AgencyVerificationDocument> AgencyVerificationDocument;
        public PendingRequestService(BaseRepository<AgencyVerificationDocument>
            _AgencyVerificationDocument)
        {
            AgencyVerificationDocument = _AgencyVerificationDocument;
        }
        public IQueryable<AgencyVerificationDocument> GetPendingAgencyRequests()
        {
            return AgencyVerificationDocument.GetList(doc => doc.status == (VerificationStatus)RequestStatus.Pending);
        }
        public bool AcceptRequest(int id, string requestType)
        {
            if (requestType == "Agency")
            {
                var request = AgencyVerificationDocument.GetById(id);
                if (request != null)
                {
                    request.status = (VerificationStatus)RequestStatus.Accepted;
                    AgencyVerificationDocument.Update(request);
                    return true;
                }
            }
            return false;
        }
        public bool RejectRequest(int id, string requestType)
        {
            if (requestType == "Agency")
            {
                var request = AgencyVerificationDocument.GetById(id);
                if (request != null)
                {
                    request.status = (VerificationStatus)RequestStatus.Rejected;
                    AgencyVerificationDocument.Update(request);
                    return true;
                }
            }
            return false;
        }
    }
}
