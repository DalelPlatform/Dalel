using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Property;
using Utilities;
using Dalel.Repository;
using Models.Enums;
using Dalel.ViewModels;

namespace Dalel.Services
{
    public class PropertyService
    {
        private readonly BookingPropertiesRepository _bookingRepo;
        private readonly PaymentPropertiesRepository _paymentRepo;
        private readonly PropertiesRepository _propertiesRepo;
        private readonly ReviewPropertiesRepository _reviewRepo;
        private readonly UploadMedia uploadMedia;
        private readonly IPaymentProcessor<PaymentProperties> paymentProcessor;

        public PropertyService(
            BookingPropertiesRepository bookingRepo,
            PaymentPropertiesRepository paymentRepo,
            PropertiesRepository propertiesRepo,
            ReviewPropertiesRepository reviewRepo,
            IPaymentProcessor<PaymentProperties> paymentProcessor,
            UploadMedia uploadMedia)
        {
            _bookingRepo = bookingRepo;
            _paymentRepo = paymentRepo;
            _propertiesRepo = propertiesRepo;
            _reviewRepo = reviewRepo;
            this.paymentProcessor = paymentProcessor;
            this.uploadMedia = uploadMedia;
        }

        #region Properties
        public ServiceResult<PaginationViewModel<PropertiesDetailsVM>> SearchProperties(
             string searchText = "",
             string city = null,
             string region = null,
             string street = null,
             string address = null,
             int NumberOfRooms = 0,
             int BuildingNo = 0,
             int FloorNo = 0,
             VerificationStatus? verificationStatus = null,
             string sortBy = "id",
             bool descending = false,
             int pageSize = 5,
             int pageIndex = 1)
        {
            try
            {
                var result = _propertiesRepo.SearchProperties(
                    searchText, city, region, street, address, NumberOfRooms, BuildingNo, FloorNo, verificationStatus,
                    sortBy, descending, pageSize, pageIndex);
                

                return ServiceResult<PaginationViewModel<PropertiesDetailsVM>>.SuccessResult(result, "Search completed.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<PropertiesDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult GetPropertyByID(int id)
        {
            try
            {
                var result = _propertiesRepo.GetPropertyById(id);
                return ServiceResult<PropertiesDetailsVM>.SuccessResult(result, "Property Found");
            }
            catch(Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);
            }
        }
        public ServiceResult<List<PropertiesDetailsVM>> GetPropertiesByOwnerId(string ownerId)
        {
            try
            {
                var properties = _propertiesRepo.GetPropertiesByOwner(ownerId);
                return ServiceResult<List<PropertiesDetailsVM>>.SuccessResult(properties, "Properties retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<List<PropertiesDetailsVM>>.FailureResult(ex.Message);
            }
        }

        public ServiceResult<List<PropertiesDetailsVM>> GetTop3Bookings()
        {
            // First, load all properties into memory
            var properties = _propertiesRepo.GetList()
                .ToList(); // <-- force immediate materialization

            var top3 = properties
                .Select(p => new
                {
                    Property = p,
                    AvgRating = p.BookingProperties
                        .Where(bp => bp.ReviewProperties != null)
                        .Select(bp => bp.ReviewProperties.Rating)
                        .DefaultIfEmpty(0)
                        .Average()
                })
                .OrderByDescending(x => x.AvgRating)
                .Take(3)
                .Select(x => x.Property.ToDetailsViewModel())
                .ToList();

            return ServiceResult<List<PropertiesDetailsVM>>.SuccessResult(top3, "bookings found");
        }

        public ServiceResult AddProperty(Properties property)
        {
            try
            {

                _propertiesRepo.Add(property);
                return ServiceResult.SuccessResult("Property added successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);
            }
        }

        public async Task<ServiceResult> EditProperty(AddPropertiesVM property,int id)
        {
            try
            {
                var existingProperty = _propertiesRepo.GetList(i => i.Id == id).FirstOrDefault();
                _propertiesRepo.Update(property.ToEditModel(existingProperty));
                return ServiceResult.SuccessResult("Property updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);
            }
        }

        public async Task<ServiceResult> DeleteProperty(int id)
        {
            try
            {
                var property = _propertiesRepo.GetList(i=>i.Id == id).FirstOrDefault();
                if (property == null)
                    return ServiceResult.FailureResult("Property not found.");

                _propertiesRepo.Delete(property);
                return ServiceResult.SuccessResult("Property deleted.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);
            }
        }

        #endregion

        #region Booking

        public  ServiceResult BookProperty(AddBookingPropertiesVM booking)
        {
            try
            {
                var property = _propertiesRepo.GetPropertyById(booking.PropertyId);
                if (property == null) // (property == null || property.IsDeleted)
                    return ServiceResult.FailureResult("Property not found.");

                if(!_propertiesRepo.CheckPropertyAvaliability(booking.CheckIn, booking.CheckOut, booking.PropertyId))
                {
                    return ServiceResult.FailureResult("This property is already booked in this date");
                }

                var numberOfNights = (booking.CheckOut - booking.CheckIn).Days;
                if (numberOfNights <= 0)
                    return ServiceResult.FailureResult("Invalid check-in/check-out dates.");

                float totalPrice = property.PricePerNight * numberOfNights;

                booking.Status = BookingStatus.Panding;
                _bookingRepo.Add(booking.ToModel(totalPrice));
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
                var booking = _bookingRepo.GetBookingById(bookingId);
                if (booking == null)
                    return ServiceResult.FailureResult("Booking not found.");

                booking.Status = BookingStatus.Cancel;
                _bookingRepo.Update(booking);
                return ServiceResult.SuccessResult("Booking canceled.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);
            }
        }

        public ServiceResult<List<BookingPropertiesDetailsVM>> GetBookingsByStatus(BookingStatus status, string ownerid)
        {
            try
            {
                var bookings = _bookingRepo.GetBookingsByStatus(status,ownerid);
                if (bookings == null)
                    return ServiceResult<List<BookingPropertiesDetailsVM>>.FailureResult("No Bookings Found");

                return ServiceResult<List<BookingPropertiesDetailsVM>>.SuccessResult(bookings, "bookings found");
            }
            catch (Exception ex)
            {
                return ServiceResult<List<BookingPropertiesDetailsVM>>.FailureResult(ex.Message);
            }
        }

        public ServiceResult<List<BookingPropertiesDetailsVM>> GetAllBookings(string ownerid)
        {
            try
            {
                var bookings = _bookingRepo.GetAllBookings(ownerid);
                if (bookings == null)
                    return ServiceResult<List<BookingPropertiesDetailsVM>>.FailureResult("No Bookings Found");

                return ServiceResult<List<BookingPropertiesDetailsVM>>.SuccessResult(bookings, "bookings found");
            }
            catch (Exception ex)
            {
                return ServiceResult<List<BookingPropertiesDetailsVM>>.FailureResult(ex.Message);
            }
        }


        #endregion

        #region Payment

        public async Task<ServiceResult> AddPayment(PaymentProperties payment)
        {
            try
            {
                var result = paymentProcessor.ProcessPayment(payment);
                if (!result.Success)
                    return result;

                // Booking confirmation logic
                var booking = _bookingRepo.GetBookingById(payment.BookingPropertyId);
                if (booking == null)
                    return ServiceResult.FailureResult("Booking not found.");

                booking.Status = BookingStatus.PaymentConfirmed;
                _bookingRepo.Update(booking);

                return ServiceResult.SuccessResult("Payment done, booking confirmed.");

            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);
            }
        }

        public async Task<ServiceResult> UpdatePaymentStatus(int paymentId, PaymentStatus newStatus)
        {
            try
            {
                var payment = _paymentRepo.GetPaymentsByID(paymentId);
                if (payment == null)
                    return ServiceResult.FailureResult("Payment not found.");

                payment.PaymentStatus = newStatus;
                _paymentRepo.Update(payment);
                return ServiceResult.SuccessResult("Payment status updated.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);
            }
        }

        #endregion

        #region Review

        public async Task<ServiceResult> AddReview(ReviewProperties review)
        {
            try
            {
                _reviewRepo.Add(review);
                return ServiceResult.SuccessResult("Review added.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);
            }
        }

        public async Task<ServiceResult> EditReview(ReviewProperties review)
        {
            try
            {
                _reviewRepo.Update(review);
                return ServiceResult.SuccessResult("Review updated.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);
            }
        }

        public async Task<ServiceResult> DeleteReview(int id)
        {
            try
            {
                var review = _reviewRepo.GetReviewByID(id);
                if (review == null)
                    return ServiceResult.FailureResult("Review not found.");

                _reviewRepo.Delete(review);
                return ServiceResult.SuccessResult("Review deleted.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);
            }
        }
        
        public async Task<ServiceResult<List<ReviewPropertiesDetailsVM>>> GetAllReviews(string ownerid)
        {
            try
            {
                var reviews = await _reviewRepo.GetAllReviews(ownerid);
                if (reviews == null || reviews.Count() <= 0)
                    return ServiceResult<List<ReviewPropertiesDetailsVM>>.FailureResult("No Reviews Found");

                return ServiceResult<List<ReviewPropertiesDetailsVM>>.SuccessResult(reviews, "Reviews found");
            }
            catch (Exception ex)
            {
                return ServiceResult<List<ReviewPropertiesDetailsVM>>.FailureResult(ex.Message);
            }
        }

        #endregion
    }
}

