using Microsoft.EntityFrameworkCore;
using Models;
using Models.Enums;
using Models.HomeService;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Dalel.Repository
{
    public class ServiceProviderPaymentRepository : BaseRepository<ServiceProviderPayment>
    {
        private readonly DelelContext _context;

        public ServiceProviderPaymentRepository(DelelContext delelContext) : base(delelContext)
        {
        }

        // Get payment by request
        public ServiceProviderPayment GetPaymentByRequest(int requestId)
        {
            return _context.ServiceProviderPayments
                .Include(p => p.ServiceRequest)
                .FirstOrDefault(p => p.RequestId == requestId);
        }

        // Get payments by provider with pagination
        public IQueryable<ServiceProviderPayment> GetPaymentsByProvider(string providerId, int pageSize = 10, int pageNumber = 1)
        {
            IQueryable<ServiceProviderPayment> query = _context.ServiceProviderPayments
                .Include(p => p.ServiceRequest)
                .Where(p => p.ServiceRequest.Propsals.Any(pr => pr.ServiceProviderId == providerId && pr.Status == ProposalStatus.Accepted));

            // Apply pagination
            if (pageSize < 1) pageSize = 10;
            if (pageNumber < 1) pageNumber = 1;

            int count = query.Count();
            if (count < pageSize)
            {
                pageSize = count;
                pageNumber = 1;
            }

            int skip = (pageNumber - 1) * pageSize;
            return query.OrderByDescending(p => p.Id)
                        .Skip(skip)
                        .Take(pageSize);
        }

        // Update payment status
        public bool UpdatePaymentStatus(int paymentId, PaymentStatus status)
        {
            var payment = base.Get(p => p.Id ==  paymentId).FirstOrDefault();
            if (payment == null) return false;

            payment.PaymentStatus = status;
            base.Update(payment);
            base.Save();
            return true;
        }
    }
}