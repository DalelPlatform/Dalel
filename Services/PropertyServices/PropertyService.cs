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

        public PropertyService(
            BookingPropertiesRepository bookingRepo,
            PaymentPropertiesRepository paymentRepo,
            PropertiesRepository propertiesRepo,
            ReviewPropertiesRepository reviewRepo)
        {
            _bookingRepo = bookingRepo;
            _paymentRepo = paymentRepo;
            _propertiesRepo = propertiesRepo;
            _reviewRepo = reviewRepo;
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

        public  ServiceResult BookProperty(BookingProperties booking,string userId)
        {
            try
            {
                var property = _propertiesRepo.GetPropertyById(booking.PropertyId);
                if (property == null) // (property == null || property.IsDeleted)
                    return ServiceResult.FailureResult("Property not found.");

                if (booking.CheckIn >= booking.CheckOut)
                    return ServiceResult.FailureResult("Invalid dates.");

                _bookingRepo.Add(booking);
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

        #endregion

        #region Payment

        public async Task<ServiceResult> AddPayment(PaymentProperties payment)
        {
            try
            {
                _paymentRepo.Add(payment);
                return ServiceResult.SuccessResult("Payment recorded.");
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

        #endregion
    }
}

