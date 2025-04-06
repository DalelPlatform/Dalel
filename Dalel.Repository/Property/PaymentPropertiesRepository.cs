using Dalel.ViewModels;
using Models;
using Models.Enums;
using Models.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Repository
{
    public class PaymentPropertiesRepository : BaseRepository<PaymentProperties>
    {
        public PaymentPropertiesRepository(DelelContext context) : base(context)
        {

        }
        public PaymentProperties GetPaymentsByID(int paymentPropertyId)
        {
            return GetList(p => p.Id == paymentPropertyId).FirstOrDefault();
        }
        public IQueryable<PaymentPropertiesDetailsVM> GetPaymentsByBookingProperty(int bookingPropertyId)
        {
            return GetList(p => p.BookingPropertyId == bookingPropertyId).Select(p=>p.ToDetailsViewModel());
        }

        public IQueryable<PaymentPropertiesDetailsVM> GetPaymentsByStatus(PaymentStatus status)
        {
            return GetList(p => p.PaymentStatus == status).Select(p => p.ToDetailsViewModel());
        }

        public IQueryable<PaymentPropertiesDetailsVM> GetPaymentsWithinDateRange(DateTime startDate, DateTime endDate)
        {
            return GetList(p => p.TransactionDateTime >= startDate && p.TransactionDateTime <= endDate).Select(p => p.ToDetailsViewModel());
        }

        public IQueryable<PaymentPropertiesDetailsVM> GetPaymentsByCode(string code)
        {
            return GetList(p => p.CodeApplied == code).Select(p => p.ToDetailsViewModel());
        }
    }
}
