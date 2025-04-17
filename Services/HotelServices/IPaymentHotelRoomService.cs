using Models.Hotel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities;

namespace Dalel.Services.HotelService
{
    public interface IPaymentHotelRoomService
    {
        Task<ServiceResult> AddPaymentAsync(PaymentHotelRoom payment);
        Task<ServiceResult> UpdatePaymentAsync(PaymentHotelRoom payment);
        Task<ServiceResult> DeletePaymentAsync(int id);
        Task<ServiceResult<PaymentHotelRoom>> GetPaymentByIdAsync(int id);
        Task<ServiceResult<IEnumerable<PaymentHotelRoom>>> GetPaymentsByStatusAsync(string status);
        Task<ServiceResult<IEnumerable<PaymentHotelRoom>>> GetPaymentsForHotelAsync(int hotelId);
        Task<ServiceResult<IEnumerable<PaymentHotelRoom>>> GetPaymentsForClientAsync(int clientId);
    }
}
