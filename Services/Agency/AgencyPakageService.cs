using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.Repository.Agency;
using Dalel.ViewModels;
using Dalel.ViewModels.Agency.AgencyPackage;
using Dalel.ViewModels.Agency.AgencyVerificationDocument;
using Dalel.ViewModels.Agency.Packagebooking;
using Dalel.ViewModels.Agency.TravelAgencies;
using Models.Agency;
using Models.Restaurant;
using Utilities;

namespace Dalel.Services.Agency
{
    public class AgencyPakageService
    {
        AgencyPackageRepo AgencyPackageRepo { get; set; }
        AgencyVerificationDocumentRepo AgencyVerificationDocumentRepo { get; set; }
        PackagebookingRepo PackagebookingRepo { get; set; }
        TravelAgenciesRepo TravelAgenciesRepo { get; set; }
        public AgencyPakageService(AgencyPackageRepo _AgencyPackageRepo,
            AgencyVerificationDocumentRepo _AgencyVerificationDocumentRepo,
             PackagebookingRepo _PackagebookingRepo,
                  TravelAgenciesRepo _TravelAgenciesRepo
            )
        {
            AgencyPackageRepo = _AgencyPackageRepo;
            AgencyVerificationDocumentRepo = _AgencyVerificationDocumentRepo;
            PackagebookingRepo = _PackagebookingRepo;
            TravelAgenciesRepo = _TravelAgenciesRepo;
        }
        public ServiceResult CreateAgencyPackage(AddAgencyPackageVM agency  )
        {
            AgencyPackageRepo.Add(agency.ToModel());
            return new ServiceResult
            {
                Success = true,
                Message = "added successfully."
            };
        }
        public ServiceResult UpdateAgencyPackage(AddAgencyPackageVM agency)
        {
            AgencyPackageRepo.Update(agency.ToModel());
            return new ServiceResult
            {
                Success = true,
                Message = "update successfully."
            };
        }
        public ServiceResult deleteAgencyPackage(int agencyId)
        {
            var _agencyPackage = AgencyPackageRepo.GetList(i => i.Id == agencyId).FirstOrDefault();
            if (_agencyPackage != null) {
                AgencyPackageRepo.Delete(_agencyPackage);
            }
            
            return new ServiceResult
            {
                Success = true,
                Message = "deleted successfully."
            };
        }
        public List<AgencyPackageDetails> GetAllAgencyPackage(int id)
        {
            return AgencyPackageRepo.GetAgencyPackage(id).ToList();
        }
       public ServiceResult AddDocument(int agencyId, string documentType, string documentFile)
        {
            AgencyVerificationDocumentRepo.AddVerificationDocument(agencyId, documentType, documentFile);
        return new ServiceResult
        {
            Success = true,
            Message = "deleted successfully."
        };
        }
        public ServiceResult UpdateDocument(addAgencyVerificationDocumentVM doc)
        {
            AgencyVerificationDocumentRepo.Update(doc.ToModel());
            return new ServiceResult
            {
                Success = true,
                Message = "update successfully."
            };
        }
        public ServiceResult delecteDocument(int id)
        {
            var Doc = AgencyVerificationDocumentRepo.
                GetList(i => i.Id == id).FirstOrDefault();
            if (Doc != null)
            {
                AgencyVerificationDocumentRepo.Delete(Doc);
            }

            return new ServiceResult
            {
                Success = true,
                Message = "deleted successfully."
            };
        }

        public List<AgencyVerificationDocumentDetails> 
            GetAllVerificationDocument(int id)
        {
            return AgencyVerificationDocumentRepo.GetApprovedDocuments(id).ToList();
        }

        public ServiceResult updataBooking(AddPackagebookingVM book)
        {
            PackagebookingRepo.Update(book.ToModel());
            return new ServiceResult
            {
                Success = true,
                Message = "update successfully."
            };
        }


        public ServiceResult delecteBooking(int id)
        {
            var booking = PackagebookingRepo.CancelBooking(id);
                

            return new ServiceResult
            {
                Success = true,
                Message = "deleted successfully."
            };
        }

        public ServiceResult<List<TravelAgenciesDetails>> GetAllTravelAgency()
        {            try
            {
                var list = TravelAgenciesRepo.GetList().
                    Select(t => t.ToDetailsModels()).ToList();
                return ServiceResult<List<TravelAgenciesDetails>>.
                    SuccessResult(list, "TravelAgencies fetched successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<List<TravelAgenciesDetails>>.FailureResult("Error: " + ex.Message);
            }

        }


        public ServiceResult CreateTravelAgencies(addTravelAgenciesVM agency)
        {
            TravelAgenciesRepo.Add(agency.ToModel());
            return new ServiceResult
            {
                Success = true,
                Message = "added successfully."
            };
        }
        public ServiceResult UpdateTravelAgencies(addTravelAgenciesVM agency)
        {
            TravelAgenciesRepo.Update(agency.ToModel());
            return new ServiceResult
            {
                Success = true,
                Message = "update successfully."
            };
        }
        public ServiceResult deleteTravelAgencies(int agencyId)
        {
            var _TravelAgencies = TravelAgenciesRepo.
                GetList(i => i.Id == agencyId).FirstOrDefault();
            if (_TravelAgencies != null)
            {
                TravelAgenciesRepo.Delete(_TravelAgencies);
            }

            return new ServiceResult
            {
                Success = true,
                Message = "deleted successfully."
            };
        }







        //Agency payment 

        //public ServiceResult CreateAgencyPackage(PackageBookingPayment agency)
        //{
        //    AgencyPaymentRepo.Add(agency);
        //    return new ServiceResult
        //    {
        //        Success = true,
        //        Message = "added successfully."
        //    };
        //}
        //public ServiceResult UpdateAgencyPackage(PackageBookingPayment agency)
        //{
        //    AgencyPaymentRepo.Update(agency);
        //    return new ServiceResult
        //    {
        //        Success = true,
        //        Message = "update successfully."
        //    };
        //}
        //public ServiceResult deleteAgencyPackage(int agencyId)
        //{
        //    var _agencyPackage = AgencyPaymentRepo.GetList(i => i.Id == agencyId).FirstOrDefault();
        //    if (_agencyPackage != null)
        //    {
        //        AgencyPaymentRepo.Delete(_agencyPackage);
        //    }

        //    return new ServiceResult
        //    {
        //        Success = true,
        //        Message = "deleted successfully."
        //    };
        //}
    }
}
