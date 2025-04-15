using Dalel.Repository.Hotel.Non_GenericRepository;
using Models.Hotel;
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

        public ServiceResult AddPayment(PaymentHotelRoom payment)
        {
            try
            {
                _paymentRepo.InsertAsync(payment).GetAwaiter().GetResult();
                _paymentRepo.SaveAsync().GetAwaiter().GetResult();
                return ServiceResult.SuccessResult("Payment added successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error adding payment: " + ex.Message);
            }
        }

        public ServiceResult UpdatePayment(PaymentHotelRoom payment)
        {
            try
            {
                _paymentRepo.UpdateAsync(payment).GetAwaiter().GetResult();
                _paymentRepo.SaveAsync().GetAwaiter().GetResult();
                return ServiceResult.SuccessResult("Payment updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error updating payment: " + ex.Message);
            }
        }

        public ServiceResult DeletePayment(int id)
        {
            try
            {
                _paymentRepo.DeleteAsync(id).GetAwaiter().GetResult();
                _paymentRepo.SaveAsync().GetAwaiter().GetResult();
                return ServiceResult.SuccessResult("Payment deleted successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error deleting payment: " + ex.Message);
            }
        }

        public ServiceResult<PaymentHotelRoom> GetPaymentById(int id)
        {
            try
            {
                var payment = _paymentRepo.GetByIdAsync(id).GetAwaiter().GetResult();
                if (payment == null)
                    return ServiceResult<PaymentHotelRoom>.FailureResult("Payment not found.");

                return ServiceResult<PaymentHotelRoom>.SuccessResult(payment, "Payment retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaymentHotelRoom>.FailureResult("Error retrieving payment: " + ex.Message);
            }
        }

        public ServiceResult<IEnumerable<PaymentHotelRoom>> GetPaymentsByStatus(string status)
        {
            try
            {
                var payments = _paymentRepo.GetPaymentsByStatusAsync(status).GetAwaiter().GetResult();
                return ServiceResult<IEnumerable<PaymentHotelRoom>>.SuccessResult(payments, "Payments retrieved successfully by status.");
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PaymentHotelRoom>>.FailureResult("Error retrieving payments by status: " + ex.Message);
            }
        }

        public ServiceResult<IEnumerable<PaymentHotelRoom>> GetPaymentsForHotel(int hotelId)
        {
            try
            {
                var payments = _paymentRepo.GetPaymentsForHotelAsync(hotelId).GetAwaiter().GetResult();
                return ServiceResult<IEnumerable<PaymentHotelRoom>>.SuccessResult(payments, "Payments retrieved successfully for hotel.");
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PaymentHotelRoom>>.FailureResult("Error retrieving payments for hotel: " + ex.Message);
            }
        }

        public ServiceResult<IEnumerable<PaymentHotelRoom>> GetPaymentsForClient(int clientId)
        {
            try
            {
                var payments = _paymentRepo.GetPaymentsForClientAsync(clientId).GetAwaiter().GetResult();
                return ServiceResult<IEnumerable<PaymentHotelRoom>>.SuccessResult(payments, "Payments retrieved successfully for client.");
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<PaymentHotelRoom>>.FailureResult("Error retrieving payments for client: " + ex.Message);
            }
        }
    }
}
