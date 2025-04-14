using Models.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Dalel.Services.HotelService
{
    public interface IPaymentHotelRoomService
    {
        ServiceResult AddPayment(PaymentHotelRoom payment);
        ServiceResult UpdatePayment(PaymentHotelRoom payment);
        ServiceResult DeletePayment(int id);
        ServiceResult<PaymentHotelRoom> GetPaymentById(int id);
        ServiceResult<IEnumerable<PaymentHotelRoom>> GetPaymentsByStatus(string status);
        ServiceResult<IEnumerable<PaymentHotelRoom>> GetPaymentsForHotel(int hotelId);
        ServiceResult<IEnumerable<PaymentHotelRoom>> GetPaymentsForClient(int clientId);
    }
}
