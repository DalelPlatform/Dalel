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
using Dalel.ViewModels.Agency.PackageSchadule;
using Dalel.ViewModels.Agency.PackageStep;
using Dalel.ViewModels.Agency.TravelAgencies;
using Models.Agency;
using Models.Enums;
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
        PackageStepRepo PackageStepRepo { get; set; }
        PackageSchaduleRepo PackageSchaduleRepo { get; set; }
        public AgencyPakageService(AgencyPackageRepo _AgencyPackageRepo,
            AgencyVerificationDocumentRepo _AgencyVerificationDocumentRepo,
             PackagebookingRepo _PackagebookingRepo,
                  TravelAgenciesRepo _TravelAgenciesRepo,
                    PackageStepRepo _PackageStepRepo ,
                      PackageSchaduleRepo _PackageSchaduleRepo
            )
        {
            AgencyPackageRepo = _AgencyPackageRepo;
            AgencyVerificationDocumentRepo = _AgencyVerificationDocumentRepo;
            PackagebookingRepo = _PackagebookingRepo;
            TravelAgenciesRepo = _TravelAgenciesRepo;
            PackageStepRepo = _PackageStepRepo;
            PackageSchaduleRepo = _PackageSchaduleRepo;

        }

        #region AgencyPackage
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

#endregion

        #region AgencyVerificationDocument
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
#endregion

        #region AgencyBooking
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
        #endregion


        #region TravelAgencies

        public ServiceResult<PaginationViewModel<TravelAgenciesDetails>> SearchTravelAgencies(
            string searchText = "",
            string BusinessCategory = "",
            string Address = "",
            string? owner = "",
            List<string>? Category = null,
            int pageSize = 10,
            int pageIndex = 1,
            string OrderBy = "Id",
            bool IsAscending = false)
        {
            try
            {
                var data = TravelAgenciesRepo.Search(
                    searchText,
                    BusinessCategory,
                    Address,
                    owner,
                    Category,
                    pageSize,
                    pageIndex,
                    OrderBy,
                    IsAscending
                );

                return ServiceResult<PaginationViewModel<TravelAgenciesDetails>>.SuccessResult(
                    data,
                    "TravelAgencies retrieved successfully"
                );
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<TravelAgenciesDetails>>.FailureResult(
                    $"Error occurred while retrieving TravelAgencies: {ex.Message}"
                );
            }
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


        public ServiceResult UpdateTravelAgencies(int id,addTravelAgenciesVM agency)
        {
            var travelAgencies = TravelAgenciesRepo.GetList(p => p.Id == id).FirstOrDefault();
            TravelAgenciesRepo.Update(agency.ToEditModel(travelAgencies));
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

        #endregion

        #region PackageStep
        public ServiceResult  <List<PackageStepDetails>> GetAllPackageStep()
        {
            try
            {
                var list = PackageStepRepo.GetList().
                    Select(t => t.ToDetailsModels()).ToList();
                return ServiceResult<List<PackageStepDetails>>.
                    SuccessResult(list, "steps fetched successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<List<PackageStepDetails>>.FailureResult("Error: " + ex.Message);
            }
        }


        public ServiceResult CreatePackageStep(addPackageStepVM step)
        {
            PackageStepRepo.Add(step.ToModel());
            return new ServiceResult
            {
                Success = true,
                Message = "added successfully."
            };
        }
        public ServiceResult UpdatePackageStep(addPackageStepVM step)
        {
            PackageStepRepo.Update(step.ToModel());
            return new ServiceResult
            {
                Success = true,
                Message = "update successfully."
            };
        }

        public ServiceResult deletePackageStep(int stepId)
        {
            var _PackageStep = PackageStepRepo.
                GetList(i => i.Id == stepId).FirstOrDefault();
            if (_PackageStep != null)
            {
                PackageStepRepo.Delete(_PackageStep);
            }

            return new ServiceResult
            {
                Success = true,
                Message = "deleted successfully."
            };
        }
        #endregion

        #region PackageSchadule
        public ServiceResult<List<PackageSchaduleDetails>> GetAllPackageSchadule()
        {
            try
            {
                var list = PackageSchaduleRepo.GetList().
                    Select(t => t.ToDetailsModels()).ToList();
                return ServiceResult<List<PackageSchaduleDetails>>.
                    SuccessResult(list, "steps fetched successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<List<PackageSchaduleDetails>>.FailureResult("Error: " + ex.Message);
            }
        }


        public ServiceResult CreatePackageSchadule(addPackageSchaduleVM Schadule)
        {
            PackageSchaduleRepo.Add(Schadule.ToModel());
            return new ServiceResult
            {
                Success = true,
                Message = "added successfully."
            };
        }
        public ServiceResult UpdatePackageSchadule(addPackageSchaduleVM Schadule)
        {
            PackageSchaduleRepo.Update(Schadule.ToModel());
            return new ServiceResult
            {
                Success = true,
                Message = "update successfully."
            };
        }

        public ServiceResult deleteSchadule(int stepId)
        {
            var _PackageSchadule = PackageSchaduleRepo.
                GetList(i => i.Id == stepId).FirstOrDefault();
            if (_PackageSchadule != null)
            {
                PackageSchaduleRepo.Delete(_PackageSchadule);
            }

            return new ServiceResult
            {
                Success = true,
                Message = "deleted successfully."
            };
        }

#endregion






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
