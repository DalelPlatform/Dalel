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
using Microsoft.AspNetCore.Http;
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
        AgencyPromotionRepo AgencyPromotionRepo { get; set; }
        public AgencyPakageService(AgencyPackageRepo _AgencyPackageRepo,
            AgencyVerificationDocumentRepo _AgencyVerificationDocumentRepo,
             PackagebookingRepo _PackagebookingRepo,
                  TravelAgenciesRepo _TravelAgenciesRepo,
                    PackageStepRepo _PackageStepRepo,
                      PackageSchaduleRepo _PackageSchaduleRepo,
            AgencyPromotionRepo _AgencyPromotionRepo
            )
        {
            AgencyPackageRepo = _AgencyPackageRepo;
            AgencyVerificationDocumentRepo = _AgencyVerificationDocumentRepo;
            PackagebookingRepo = _PackagebookingRepo;
            TravelAgenciesRepo = _TravelAgenciesRepo;
            PackageStepRepo = _PackageStepRepo;
            PackageSchaduleRepo = _PackageSchaduleRepo;
            AgencyPromotionRepo = _AgencyPromotionRepo;

        }

        #region AgencyPackage
        public ServiceResult CreateAgencyPackage(AddAgencyPackageVM agency)
        {
            var files = new FormFileCollection();
            if (agency.ImageFile != null && agency.ImageFile.Length > 0)
            {
                files.Add(agency.ImageFile);
            }
            foreach (var step in agency.Steps)
            {
                Console.WriteLine(step.ImageFile);
                if (step.ImageFile != null && step.ImageFile.Length > 0)
                {
                    files.Add(step.ImageFile);
                }
            }
            var uploader = new UploadMedia();
            var uploadedUrls = uploader.addimage(files);
            int index = 0;
            if (agency.ImageFile != null && index < uploadedUrls.Count)
            {
                agency.ImagePath = uploadedUrls[index];
                index++;
            }
            for (int i = 0; i < agency.Steps.Count; i++)
            {
                if (agency.Steps[i].ImageFile != null && index < uploadedUrls.Count)
                {
                    agency.Steps[i].Image = uploadedUrls[index];
                    index++;
                }
            }
            AgencyPackageRepo.Add(agency.ToModel());
            return new ServiceResult
            {
                Success = true,
                Message = "added successfully."
            };
        }
       
        public ServiceResult UpdateAgencyPackage(int id, AddAgencyPackageVM agency)
        {
            var package = AgencyPackageRepo.GetList(p => p.Id == id).FirstOrDefault();
            AgencyPackageRepo.Update(agency.ToEditModel(package));
            return new ServiceResult
            {
                Success = true,
                Message = "update successfully."
            };
        }
        public ServiceResult deleteAgencyPackage(int id)
        {
            var _agencyPackage = AgencyPackageRepo.GetList(i => i.Id == id).FirstOrDefault();
            if (_agencyPackage != null)
            {
                var steps = PackageStepRepo.GetList(s => s.PackageId
                == _agencyPackage.Id).ToList();
                foreach (var step in steps)
                {
                    PackageStepRepo.Delete(step);
                }
                var schedules = PackageSchaduleRepo.GetList(s => s.PackageId == _agencyPackage.Id).ToList();
                foreach (var sch in schedules)
                {
                    PackageSchaduleRepo.Delete(sch);
                }
                AgencyPackageRepo.Delete(_agencyPackage);
            }
               
         
            return new ServiceResult
            {
                Success = true,
                Message = "deleted successfully.",
                StatusCode=200

            };
        }


        public ServiceResult<PaginationViewModel<AgencyPackageDetails>> SearchAgencyPackage(
            string searchText = "",
      string Name = "",
      float Price = 0,

      int pageSize = 10,
      int pageIndex = 1,
      string OrderBy = "Id",
      bool IsAscending = false)
        {
            try
            {
                var data = AgencyPackageRepo.Search(
                       searchText,
                       Name,
                       Price,

                       pageSize,
                       pageIndex,
                       OrderBy,
                      IsAscending
                );

                return ServiceResult<PaginationViewModel<AgencyPackageDetails>>.
                    SuccessResult(
                    data,
                    "TravelAgencies retrieved successfully"
                );
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<AgencyPackageDetails>>.
                    FailureResult(
                    $"Error occurred while retrieving TravelAgencies: {ex.Message}"
                );
            }
        }

        public List<AgencyPackageDetails> GetAllAgencyPackage(int id)
        {
            Console.WriteLine(AgencyPackageRepo.GetAgencyPackage(id).ToList());
            return AgencyPackageRepo.GetAgencyPackage(id).ToList();
        }

        public ServiceResult<AgencyPackageDetails> Getpackagebyid(int id)
        {
            try
            {
                var package = AgencyPackageRepo.GetList(a => a.Id == id).
                    Select(t => t.ToDetailsModels()).FirstOrDefault();
                if (package == null)
                {
                    return ServiceResult<AgencyPackageDetails>.
                        FailureResult("package not found.");
                }
                return ServiceResult<AgencyPackageDetails>.
                    SuccessResult(package, "package fetched successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<AgencyPackageDetails>.FailureResult("Error: " + ex.Message);
            }

        }

        public ServiceResult BookPackage(AddPackagebookingVM booking)
        {
            try
            {
                var package = AgencyPackageRepo.GetPackageById(booking.PackageId);
                if (package == null) 
                    return ServiceResult.FailureResult("package not found.");
                // shud_id check valid or not
                // pack avalib for slots
                // pricepck * reserved preple
              

            

                booking.BookingStatus = BookingStatus.Panding;
                //PackagebookingRepo.Add(booking.ToModel(totalPrice));
                return ServiceResult.SuccessResult("Booking created.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);
            }
        }



        public async Task<ServiceResult> CancelBooking(int bookingId)
        {
            try
            {
                var booking = PackagebookingRepo.GetBookingById(bookingId);
                if (booking == null)
                    return ServiceResult.FailureResult("Booking not found.");

                booking.BookingStatus = BookingStatus.Cancel;
                PackagebookingRepo.Update(booking);
                return ServiceResult.SuccessResult("Booking canceled.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);
            }
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
        public ServiceResult UpdateDocument(int id, addAgencyVerificationDocumentVM doc)
        {
            var VerificationDocument = AgencyVerificationDocumentRepo.GetList(p => p.Id == id).FirstOrDefault();

            AgencyVerificationDocumentRepo.Update(doc.ToEditModel(VerificationDocument));
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
        public ServiceResult updataBooking(int id, AddPackagebookingVM book)
        {
            var AgencyBooking = PackagebookingRepo.GetList(p => p.Id == id).FirstOrDefault();

            PackagebookingRepo.Update(book.ToEditModel(AgencyBooking));
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
        public ServiceResult<List<TravelAgenciesDetails>> GetAllTravelAgency(string ownerId)
        {
            try
            {
                var list = TravelAgenciesRepo.GetList(a => a.OwnerId == ownerId).
                    Select(t => t.ToDetailsModels()).ToList();
                Console.WriteLine(list);
                return ServiceResult<List<TravelAgenciesDetails>>.
                    SuccessResult(list, "TravelAgencies fetched successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<List<TravelAgenciesDetails>>.FailureResult("Error: " + ex.Message);
            }

        }

        public ServiceResult<TravelAgenciesDetails> GetTravelAgencybyid(int id)
        {
            try
            {
                var agency = TravelAgenciesRepo.GetList(a => a.Id == id).
                    Select(t => t.ToDetailsModels()).FirstOrDefault();
                if(agency == null)
                {
                    return ServiceResult<TravelAgenciesDetails>.FailureResult("Agency not found.");
                }
                return ServiceResult<TravelAgenciesDetails>.SuccessResult(agency, "Agency fetched successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<TravelAgenciesDetails>.FailureResult("Error: " + ex.Message);
            }

        }

        //public ServiceResult CreateTravelAgencies(addTravelAgenciesVM agency)
        //{
        //    var travelAgency = agency.ToModel();
        //    TravelAgenciesRepo.Add(travelAgency);
        //    if (agency.VerificationDocument != null && agency.VerificationDocument.Any())
        //    {
        //        string basePath = Path.Combine(Directory.GetCurrentDirectory(), 
        //            "wwwroot", "Uploads", "AgencyDocuments");
        //        if (!Directory.Exists(basePath))
        //        {
        //            Directory.CreateDirectory(basePath);
        //        }
        //        foreach (var doc in agency.VerificationDocument)
        //        {
        //            if (doc.DocumentFile != null && doc.DocumentFile.Length > 0)
        //            {
        //                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(doc.DocumentFile.FileName);
        //                string filePath = Path.Combine(basePath, fileName);

        //                using (var stream = new FileStream(filePath, FileMode.Create))
        //                {
        //                    doc.DocumentFile.CopyTo(stream);
        //                }
        //                doc.DocumentFileName = fileName;
        //                var documentEntity = doc.ToModel(); 
        //                documentEntity.AgencyId = travelAgency.Id;

        //                AgencyVerificationDocumentRepo.Add(documentEntity);
        //            }
        //        }

        //        }

        //    return new ServiceResult
        //    {
        //        Success = true,
        //        Message = "added successfully."
        //    };
        //}
        public ServiceResult CreateTravelAgencies(addTravelAgenciesVM agency)
        {
            var travelAgency = agency.ToModel();
       

            if (agency.VerificationDocument != null && agency.VerificationDocument.Any())
            {
                var uploadService = new UploadMedia();

                foreach (var doc in agency.VerificationDocument)
                {
                    if (doc.DocumentFile != null && doc.DocumentFile.Length > 0)
                    {
                        var fileList = new FormFileCollection { doc.DocumentFile };
                        var uploadedUrls = uploadService.addimage(fileList);

                        if (uploadedUrls.Any())
                        {
                            doc.DocumentFileName = uploadedUrls[0];
                            var documentEntity = doc.ToModel();
                            documentEntity.AgencyId = travelAgency.Id;
                            AgencyVerificationDocumentRepo.Add(documentEntity);
                        }
                    }
                }
            }
            TravelAgenciesRepo.Add(travelAgency);
            return new ServiceResult
            {
                Success = true,
                Message = "added successfully."
            };
        }


        public ServiceResult UpdateTravelAgencies(int id, addTravelAgenciesVM agency)
        {
            var travelAgency = TravelAgenciesRepo.GetList(p => p.Id == id).FirstOrDefault();
            if (travelAgency == null)
            {
                return new ServiceResult
                {
                    Success = false,
                    Message = "Agency not found."
                };
            }

            var updatedAgency = agency.ToEditModel(travelAgency);

            if (agency.VerificationDocument != null && agency.VerificationDocument.Any())
            {
               
                var oldDocs = AgencyVerificationDocumentRepo.
                    GetList(d => d.AgencyId == id).ToList();
                foreach (var doc in oldDocs)
                {
                    AgencyVerificationDocumentRepo.Delete(doc);
                }

                var uploadService = new UploadMedia();
                foreach (var doc in agency.VerificationDocument)
                {
                    
                    if (doc.keepPrevious && string.IsNullOrEmpty(doc.DocumentFileName))
                    {
                        continue; 
                    }

                    if (doc.keepPrevious && doc.DocumentFile == null)
                    {
                     
                        var documentEntity = doc.ToModel();
                        documentEntity.AgencyId = id;
                        AgencyVerificationDocumentRepo.Add(documentEntity);
                    }
                 
                    else if (doc.DocumentFile != null && doc.DocumentFile.Length > 0)
                    {
                        var fileList = new FormFileCollection { doc.DocumentFile };
                        var uploadedUrls = uploadService.addimage(fileList);

                        if (uploadedUrls.Any())
                        {
                            doc.DocumentFileName = uploadedUrls[0];
                            var documentEntity = doc.ToModel();
                            documentEntity.AgencyId = id;
                            AgencyVerificationDocumentRepo.Add(documentEntity);
                        }
                    }
                }
            }

            TravelAgenciesRepo.Update(updatedAgency);

            return new ServiceResult
            {
                Success = true,
                Message = "Agency updated successfully."
            };
        }


        public ServiceResult deleteTravelAgencies(int agencyId)
        {
            var agency = TravelAgenciesRepo.GetList(i => i.Id == agencyId).FirstOrDefault();

            if (agency == null)
            {
                return new ServiceResult
                {
                    Success = false,
                    Message = "Agency not found."
                };
            }

            var relatedDocs = AgencyVerificationDocumentRepo.
                GetList(d => d.AgencyId == agencyId).ToList();

            if (relatedDocs.Any())
            {
                foreach (var doc in relatedDocs)
                {
                    AgencyVerificationDocumentRepo.Delete(doc);
                }
            }
            var packages = AgencyPackageRepo.GetList(p => p.AgencyId == agencyId).ToList();
            foreach (var pkg in packages)
            {
                var steps = PackageStepRepo.GetList(s => s.PackageId == pkg.Id).ToList();
                foreach (var step in steps)
                    PackageStepRepo.Delete(step);

                var schedules = PackageSchaduleRepo.GetList(s => s.PackageId == pkg.Id).ToList();
                foreach (var sch in schedules)
                    PackageSchaduleRepo.Delete(sch);

                AgencyPackageRepo.Delete(pkg);
            }
            
            var promotion = AgencyPromotionRepo.GetList(p => p.AgencyId == agencyId).ToList();
            foreach(var prom in promotion)
                AgencyPromotionRepo.Delete(prom);
            
            TravelAgenciesRepo.Delete(agency);

            return new ServiceResult
            {
                Success = true,
                Message = " Agency deleted successfully."
            };
        }


        #endregion

        #region PackageStep
        public ServiceResult<List<PackageStepDetails>> GetAllPackageStep()
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
        public ServiceResult UpdatePackageStep(int id, addPackageStepVM step)
        {
            var PackageStep = PackageStepRepo.GetList(p => p.Id == id).FirstOrDefault();

            PackageStepRepo.Update(step.ToEditModel(PackageStep));
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
        public ServiceResult UpdatePackageSchadule(int id, addPackageSchaduleVM Schadule)
        {
            var PackageSchadule = PackageSchaduleRepo.GetList(p => p.Id == id).FirstOrDefault();

            PackageSchaduleRepo.Update(Schadule.ToEditModel(PackageSchadule));
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