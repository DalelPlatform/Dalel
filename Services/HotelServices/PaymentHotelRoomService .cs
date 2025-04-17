using Dalel.Repository.Hotel.Non_GenericRepository;
using Models.Hotel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities;

namespace Dalel.Services.HotelService
{
    public class PaymentHotelRoomService : IPaymentHotelRoomService
    {
        private readonly PaymentHotelRoomRepository _paymentRepo;

        public PaymentHotelRoomService(PaymentHotelRoomRepository paymentRepo)
        {
            _paymentRepo = paymentRepo;
        }

        public async Task<ServiceResult> AddPaymentAsync(PaymentHotelRoom payment)
        {
            try
            {
                await _paymentRepo.InsertAsync(payment);
                await _paymentRepo.SaveAsync();
                return ServiceResult.SuccessResult("Payment added successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error adding payment: " + ex.Message);
            }
        }

        public async Task<ServiceResult> UpdatePaymentAsync(PaymentHotelRoom payment)
        {
            try
            {
                await _paymentRepo.UpdateAsync(payment);
                await _paymentRepo.SaveAsync();
                return ServiceResult.SuccessResult("Payment updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error updating payment: " + ex.Message);
            }
        }

        public async Task<ServiceResult> DeletePaymentAsync(int id)
        {
            try
            {
                await _paymentRepo.DeleteAsync(id);
                await _paymentRepo.SaveAsync();
                return ServiceResult.SuccessResult("Payment deleted successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error deleting payment: " + ex.Message);
            }
        }

        public async Task<ServiceResult<PaymentHotelRoom>> GetPaymentByIdAsync(int id)
        {
            try
            {
                var payment = await _paymentRepo.GetByIdAsync(id);
                if (payment == null)
                    return ServiceResult<PaymentHotelRoom>.FailureResult("Payment not found.");

                return ServiceResult<PaymentHotelRoom>.SuccessResult(payment, "Payment retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaymentHotelRoom>.FailureResult("Error retrieving payment: " + ex.Message);
            }
        }

        public async Task<ServiceResult<IEnumerable<PaymentHotelRoom>>> GetPaymentsByStatusAsync(string status)
        {
            try
            {
                var payments = await _paymentRepo.GetPaymentsByStatusAsync(status);
                return ServiceResult<IEnumerable<PaymentHotelRoom>>.SuccessResult(payments, "Payments retrieved successfully by status.");
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PaymentHotelRoom>>.FailureResult("Error retrieving payments by status: " + ex.Message);
            }
        }

        public async Task<ServiceResult<IEnumerable<PaymentHotelRoom>>> GetPaymentsForHotelAsync(int hotelId)
        {
            try
            {
                var payments = await _paymentRepo.GetPaymentsForHotelAsync(hotelId);
                return ServiceResult<IEnumerable<PaymentHotelRoom>>.SuccessResult(payments, "Payments retrieved successfully for hotel.");
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PaymentHotelRoom>>.FailureResult("Error retrieving payments for hotel: " + ex.Message);
            }
        }

        public async Task<ServiceResult<IEnumerable<PaymentHotelRoom>>> GetPaymentsForClientAsync(int clientId)
        {
            try
            {
                var payments = await _paymentRepo.GetPaymentsForClientAsync(clientId);
                return ServiceResult<IEnumerable<PaymentHotelRoom>>.SuccessResult(payments, "Payments retrieved successfully for client.");
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PaymentHotelRoom>>.FailureResult("Error retrieving payments for client: " + ex.Message);
            }
        }
    }
}
