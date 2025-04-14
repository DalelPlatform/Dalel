using System;
using System.Linq;
using System.Threading.Tasks;
using Dalel.Reopsitory;
using Dalel.Repository;
using Models;
using Models.Driver;
using Models.Enums;
using Utilities;

namespace Dalel.Services
{
    public class VehicleService
    {
        private readonly VehicleRepository _vehicleRepo;
        private readonly ReviewVehicleRepository _reviewRepo;
        private readonly PaymentVehicleRepository _paymentRepo;
        private readonly CarProposalRepository _proposalRepo;
        private readonly BookingVehicleRepository _bookingRepo;

        public VehicleService(
            VehicleRepository vehicleRepo,
            ReviewVehicleRepository reviewRepo,
            PaymentVehicleRepository paymentRepo,
            CarProposalRepository proposalRepo,
            BookingVehicleRepository bookingRepo)
        {
            _vehicleRepo = vehicleRepo;
            _reviewRepo = reviewRepo;
            _paymentRepo = paymentRepo;
            _proposalRepo = proposalRepo;
            _bookingRepo = bookingRepo;
        }

        #region Vehicle

        public async Task<ServiceResult> AddVehicle(Vehicle vehicle)
        {
            try
            {
                _vehicleRepo.Add(vehicle);
                return ServiceResult.SuccessResult("Vehicle added successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);
            }
        }

        public async Task<ServiceResult> EditVehicle(Vehicle vehicle)
        {
            try
            {
                _vehicleRepo.Update(vehicle);
                return ServiceResult.SuccessResult("Vehicle updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);
            }
        }

        public async Task<ServiceResult> DeleteVehicle(int id)
        {
            try
            {
                var vehicle = _vehicleRepo.GetList(v => v.Id == id).FirstOrDefault();
                if (vehicle == null)
                    return ServiceResult.FailureResult("Vehicle not found.");

                _vehicleRepo.Delete(vehicle);
                return ServiceResult.SuccessResult("Vehicle deleted.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);
            }
        }

        #endregion

        #region Review

        public async Task<ServiceResult> AddReview(ReviewVehicle review)
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

        public async Task<ServiceResult> EditReview(ReviewVehicle review)
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
                var review = _reviewRepo.GetList(r => r.Id == id).FirstOrDefault();
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

        #region Payment

        public async Task<ServiceResult> AddPayment(PaymentVehicle payment)
        {
            try
            {
                _paymentRepo.Add(payment);
                return ServiceResult.SuccessResult("Payment added.");
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
                var payment = _paymentRepo.GetList(p => p.Id == paymentId).FirstOrDefault();
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

        #region Car Proposal

        public async Task<ServiceResult> AddProposal(CarProposal proposal)
        {
            try
            {
                _proposalRepo.Add(proposal);
                return ServiceResult.SuccessResult("Car proposal added.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);
            }
        }

        public async Task<ServiceResult> EditProposal(CarProposal proposal)
        {
            try
            {
                _proposalRepo.Update(proposal);
                return ServiceResult.SuccessResult("Car proposal updated.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);
            }
        }

        public async Task<ServiceResult> DeleteProposal(int id)
        {
            try
            {
                var proposal = _proposalRepo.GetList(p => p.Id == id).FirstOrDefault();
                if (proposal == null)
                    return ServiceResult.FailureResult("Proposal not found.");

                _proposalRepo.Delete(proposal);
                return ServiceResult.SuccessResult("Car proposal deleted.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);
            }
        }

        #endregion

        #region Booking

        public async Task<ServiceResult> AddBooking(BookingVehicle booking)
        {
            try
            {
                _bookingRepo.Add(booking);
                return ServiceResult.SuccessResult("Booking added.");
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
                var booking = _bookingRepo.GetList(b => b.Id == bookingId).FirstOrDefault();
                if (booking == null)
                    return ServiceResult.FailureResult("Booking not found.");

                booking.BookingStatus = BookingStatus.Rejected;
                _bookingRepo.Update(booking);
                return ServiceResult.SuccessResult("Booking canceled.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);
            }
        }

        #endregion
    }
}
