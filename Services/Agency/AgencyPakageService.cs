using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.Repository.Agency;
using Dalel.ViewModels;
using Dalel.ViewModels.Agency.AgencyPackage;
using Dalel.ViewModels.Agency.AgencyReview;
using Dalel.ViewModels.Agency.AgencyVerificationDocument;
using Dalel.ViewModels.Agency.Packagebooking;
using Dalel.ViewModels.Agency.PackageSchadule;
using Dalel.ViewModels.Agency.PackageStep;
using Dalel.ViewModels.Agency.TravelAgencies;
using Dalel.ViewModels.notification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Models.Agency;
using Models.Enums;
using Models.Notification;
using Models.Property;
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
        NotificationRepo NotificationRepo { get; set; }
        PackageBookingReviewRepo PackageBookingReviewRepo { get; set; }

        private readonly IPaymentProcessor<PackageBookingPayment> paymentProcessor;
        public AgencyPakageService(AgencyPackageRepo _AgencyPackageRepo,
            AgencyVerificationDocumentRepo _AgencyVerificationDocumentRepo,
             PackagebookingRepo _PackagebookingRepo,
                  TravelAgenciesRepo _TravelAgenciesRepo,
                    PackageStepRepo _PackageStepRepo,
                      PackageSchaduleRepo _PackageSchaduleRepo,
            AgencyPromotionRepo _AgencyPromotionRepo,
             IPaymentProcessor<PackageBookingPayment> paymentProcessor,
             NotificationRepo _notificationRepo,
              PackageBookingReviewRepo _PackageBookingReviewRepo

            )
        {
            AgencyPackageRepo = _AgencyPackageRepo;
            AgencyVerificationDocumentRepo = _AgencyVerificationDocumentRepo;
            PackagebookingRepo = _PackagebookingRepo;
            TravelAgenciesRepo = _TravelAgenciesRepo;
            PackageStepRepo = _PackageStepRepo;
            PackageSchaduleRepo = _PackageSchaduleRepo;
            AgencyPromotionRepo = _AgencyPromotionRepo;
            this.paymentProcessor = paymentProcessor;
            NotificationRepo = _notificationRepo;
            PackageBookingReviewRepo = _PackageBookingReviewRepo;

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
                //var steps = PackageStepRepo.GetList(s => s.PackageId
                //== _agencyPackage.Id).ToList();
                //foreach (var step in steps)
                //{
                //    PackageStepRepo.Delete(step);
                //}
                //var schedules = PackageSchaduleRepo.GetList(s => s.PackageId 
                //== _agencyPackage.Id).ToList();
                //foreach (var sch in schedules)
                //{
                //    PackageSchaduleRepo.Delete(sch);
                //}
                _agencyPackage.PackageSchadules.Clear();
                _agencyPackage.PackageSteps.Clear();
                AgencyPackageRepo.Delete(_agencyPackage);
            }


            return new ServiceResult
            {
                Success = true,
                Message = "deleted successfully.",
                StatusCode = 200

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



        public ServiceResult BookPackage(AddPackagebookingVM booking)
        {
            try
            {
                // shud_id check valid or not
                var schadule = PackageSchaduleRepo.GetById(booking.PackageSchaduleId);

                if (schadule == null)
                {
                    return ServiceResult.FailureResult("Schedule not found ");
                }
                if (schadule.Date.Date < DateTime.Now.Date)
                {
                    return ServiceResult.FailureResult("Schedule date has already passed.");
                }
                if (booking.Date.Date > schadule.Date.Date)
                {
                    return ServiceResult.FailureResult("invalide time ");
                }
                // pack avalib for slots
                var alreadyReserved = PackagebookingRepo.GetList(b =>
                    b.PackageSchaduleId == booking.PackageSchaduleId &&
                    b.BookingStatus == BookingStatus.PaymentConfirmed)
                    .Sum(b => (int?)b.ReservedPeople) ?? 0;
                var availableSlots = schadule.SlotsAvailable - alreadyReserved;

                // pricepck * reserved preple
                if (booking.ReservedPeople > availableSlots)
                    return ServiceResult.FailureResult($"Only {availableSlots} slot(s) left on this date.");
                float unitPrice = schadule.AgencyPackage.Price;
                float totalprice = unitPrice * booking.ReservedPeople;


                //booking.BookingStatus = BookingStatus.Panding;
                var newBooking = booking.ToModel(totalprice);
                PackagebookingRepo.Add(newBooking);
                return ServiceResult<PackageBooking>.SuccessResult(newBooking, "Booking created.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);
            }
        }

        public (string OwnerId, AgencyPackageDetails Package) GetOwnerIdBySchaduleId(int schaduleId)
        {
            var schadule = PackageSchaduleRepo.GetList(s => s.Id == schaduleId).FirstOrDefault();
            if (schadule == null)
                throw new Exception("Schadule not found");
            var package = AgencyPackageRepo.GetList(p => p.Id == schadule.PackageId).FirstOrDefault();

            if (package == null)
                throw new Exception("Package not found");
            var agency = TravelAgenciesRepo.GetList(a => a.Id == package.AgencyId)
                   .FirstOrDefault();

            if (agency == null)
                throw new Exception("Agency not found");
            var packageVM = package.ToDetailsModels();
            return (agency.OwnerId, packageVM);
        }
        public ServiceResult showAllBooking(string clientId)
        {
            try
            {
                var allBooking = PackagebookingRepo.GetList(c => c.ClientId == clientId).
                  Select(t => t.ToDetailsModels()).ToList();

                return ServiceResult<List<PackagebookingDetails>>.
                    SuccessResult(allBooking, "booking fetched successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<List<TravelAgenciesDetails>>.FailureResult("Error: " + ex.Message);
            }
        }




        public async Task<ServiceResult> CancelBooking(int bookingId)
        {
            try
            {
                var booking = PackagebookingRepo.GetBookingById(bookingId);
                if (booking == null)
                    return ServiceResult.FailureResult("Booking not found.");
                if (booking.BookingStatus == BookingStatus.Cancel)
                    return ServiceResult.FailureResult("Booking already canceled.");
                booking.BookingStatus = BookingStatus.Cancel;
                PackagebookingRepo.Update(booking);
                return ServiceResult.SuccessResult("Booking canceled.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);
            }
        }


        public ServiceResult<PackageBooking> GetBookingById(int bookingId)
        {
            try
            {
                var booking = PackagebookingRepo.GetBookingById(bookingId);
                if (booking == null)
                    return ServiceResult<PackageBooking>.
                        FailureResult("Booking not found.");


                return ServiceResult<PackageBooking>.SuccessResult(booking, "Booking fetched successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PackageBooking>.FailureResult(ex.Message);
            }
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

                return ServiceResult<PaginationViewModel<TravelAgenciesDetails>>.
                    SuccessResult(
                    data,
                    "TravelAgencies retrieved successfully"
                );
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<TravelAgenciesDetails>>.
                    FailureResult(
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
                if (agency == null)
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
            foreach (var prom in promotion)
                AgencyPromotionRepo.Delete(prom);

            TravelAgenciesRepo.Delete(agency);

            return new ServiceResult
            {
                Success = true,
                Message = " Agency deleted successfully."
            };
        }

        public float GetOwnerEarnings(string ownerId)
        {
            var agencyIds = TravelAgenciesRepo.GetList(a => a.OwnerId == ownerId)
         .Select(a => a.Id).ToList();
            if (!agencyIds.Any())
                return 0;
            var packageIds = AgencyPackageRepo.
                GetList(p => agencyIds.Contains(p.AgencyId)).Select(p => p.Id).ToList();
            if (!packageIds.Any())
                return 0;
            var schaduleIds = PackageSchaduleRepo.
                GetList(s => packageIds.Contains(s.PackageId)).Select(s => s.Id).ToList();
            if (!schaduleIds.Any())
                return 0;
            var confirmedBookings = PackagebookingRepo.GetList(b => schaduleIds.Contains(b.PackageSchaduleId)
            && b.BookingStatus == BookingStatus.PaymentConfirmed).ToList();
            if (!confirmedBookings.Any())
                return 0;
            var totalEarnings = confirmedBookings.Sum(b => b.TotalPrice);

            return totalEarnings;
        }
        public int GetOwnerTotalReviews(string ownerId)
        {
            var agencyIds = TravelAgenciesRepo.GetList(a => a.OwnerId == ownerId)
                .Select(a => a.Id).ToList();

            if (!agencyIds.Any())
                return 0;

            var packageIds = AgencyPackageRepo.GetList(p => agencyIds.Contains(p.AgencyId))
                .Select(p => p.Id).ToList();

            if (!packageIds.Any())
                return 0;

            var schaduleIds = PackageSchaduleRepo.GetList(s => packageIds.Contains(s.PackageId))
                .Select(s => s.Id).ToList();

            if (!schaduleIds.Any())
                return 0;

            var bookings = PackagebookingRepo.GetList(b => schaduleIds.Contains(b.PackageSchaduleId))
                .Select(b => b.Id).ToList();

            if (!bookings.Any())
                return 0;

            var totalReviews = PackageBookingReviewRepo.GetList(r => bookings.Contains(r.BookingId)).Count();

            return totalReviews;
        }
        public double GetOwnerAverageRating(string ownerId)
        {
            var agencyIds = TravelAgenciesRepo.GetList(a => a.OwnerId == ownerId)
                                              .Select(a => a.Id).ToList();
            if (!agencyIds.Any())
                return 0;

            var packageIds = AgencyPackageRepo.GetList(p => agencyIds.Contains(p.AgencyId))
                                              .Select(p => p.Id).ToList();
            if (!packageIds.Any())
                return 0;

            var schaduleIds = PackageSchaduleRepo.GetList(s => packageIds.Contains(s.PackageId))
                                                 .Select(s => s.Id).ToList();
            if (!schaduleIds.Any())
                return 0;

            var bookingIds = PackagebookingRepo.GetList(b => schaduleIds.Contains(b.PackageSchaduleId))
                                               .Select(b => b.Id).ToList();
            if (!bookingIds.Any())
                return 0;

            var ratings = PackageBookingReviewRepo.GetList(r => bookingIds.Contains(r.BookingId))
                                                  .Select(r => r.Rating);

            if (!ratings.Any())
                return 0;

            return Math.Round(ratings.Average(), 1);
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



        public ServiceResult<PackageSchaduleDetails> GetSchadulebyid(int id)
        {
            try
            {
                var PackageSchadule = PackageSchaduleRepo.GetList(a => a.Id == id).
                    Select(t => t.ToDetailsModels()).FirstOrDefault();
                if (PackageSchadule == null)
                {
                    return ServiceResult<PackageSchaduleDetails>.
                        FailureResult("package not found.");
                }
                return ServiceResult<PackageSchaduleDetails>.
                    SuccessResult(PackageSchadule, "package fetched successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PackageSchaduleDetails>.FailureResult("Error: " + ex.Message);
            }

        }

        public ServiceResult<List<PackageSchaduleDetails>> GetSchadulesByPackageId(int packageId)
        {
            try
            {

                var schadules = PackageSchaduleRepo.GetList(s => s.PackageId ==
                packageId)
                    .ToList()
                    .Select(s => s.ToDetailsModels())
                    .ToList();

                if (schadules == null || !schadules.Any())
                    return ServiceResult<List<PackageSchaduleDetails>>.FailureResult("No schadules found for this package.");

                return ServiceResult<List<PackageSchaduleDetails>>.SuccessResult(schadules, "Schadules fetched successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<List<PackageSchaduleDetails>>.FailureResult(ex.Message);
            }
        }


        #endregion



        //payment 

        public async Task<ServiceResult> AddPayment(PackageBookingPayment payment)
        {
            try
            {
                var result = paymentProcessor.ProcessPayment(payment);
                if (!result.Success)
                    return result;

                // Booking confirmation logic
                var booking = PackagebookingRepo.GetBookingById(payment.BookingId);
                if (booking == null)
                    return new ServiceResult
                    {
                        Success = false,
                        Message = "Booking not found"
                    };

                booking.BookingStatus = BookingStatus.PaymentConfirmed;
                payment.Date = DateTime.Now;
                PackagebookingRepo.Update(booking);

                return ServiceResult.SuccessResult("Payment done, booking confirmed.");

            }
            catch (Exception ex)
            {
                //return ServiceResult.FailureResult(ex.Message);
                return new ServiceResult
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }




        //Notification
        public Notification AddNotification(AddNotificationVM vm)
        {
            var notification = vm.ToModel();
            NotificationRepo.Add(notification);
            return notification;
        }
        public List<NotificationDetailsVM> GetUserNotifications(string userId)
        {

            var notifications = NotificationRepo.GetList(n => n.UserId == userId && !n.IsRead);

            if (notifications == null)
                return new List<NotificationDetailsVM>();
            Console.WriteLine($"Notifications Count: {notifications}");

            return notifications.OrderByDescending(n => n.CreatedAt)
                                .Select(n => n.ToDetailsVM())
                                .ToList();
        }

        public void MarkAsRead(int notificationId, string userId)
        {
            var notification = NotificationRepo.GetList(n => n.Id == notificationId && n.UserId == userId)
                                                .FirstOrDefault();
            if (notification != null)
            {
                notification.IsRead = true;
                NotificationRepo.Update(notification);
            }
        }


        //Hangfire 

        public async Task SendReviewNotifications()
        {
            var finishedBookings = PackagebookingRepo.GetList(
                b => b.BookingStatus == BookingStatus.PaymentConfirmed &&
              b.PackageSchadule.Date < DateTime.UtcNow &&
                b.Review == null
                ).ToList();
            Console.WriteLine("b.PackageSchadule.Date.Date ", finishedBookings);
            foreach (var booking in finishedBookings)
            {
                var notification = new AddNotificationVM
                {
                    UserId = booking.ClientId,
                    Message = $"please rate package: " +
                    $"{booking.PackageSchadule.AgencyPackage.Name} | BookingId:{booking.Id}",
                    CreatedAt = DateTime.Now
                };
                AddNotification(notification);

            }
            Console.WriteLine("notification from back");
        }


        public ServiceResult AddPackageReview(AddAgencyReview reviewVM, string userId)
        {

            var booking = PackagebookingRepo.GetBookingById(reviewVM.BookingId);
            if (booking == null)
                return ServiceResult.FailureResult("Booking not found.");
            if (booking.ClientId != userId)
                return ServiceResult.FailureResult("You can only review your own bookings.");

            if (booking.PackageSchadule.Date > DateTime.Now)
                return ServiceResult.FailureResult("You can only review after the package date is finished.");
            if (booking.Review != null)
                return ServiceResult.FailureResult("You have already reviewed this booking.");
            PackageBookingReviewRepo.Add(reviewVM.ToModel());
            return ServiceResult.SuccessResult("Review added successfully.");

        }

        public List<AgencyReviewDetails> getPackageReviews(int packageId)
        {
            return PackageBookingReviewRepo.GetReviewsByPackageId(packageId).ToList();
        }

    }
}