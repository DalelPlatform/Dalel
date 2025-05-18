using Dalel.Repository;
using Dalel.ViewModels;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Driver;
using Models.Enums;
using System.Linq.Expressions;

namespace Dalel.Reopsitory
{
    public class PaymentVehicleRepository : BaseRepository<PaymentVehicle>
    {
        public PaymentVehicleRepository(DelelContext context) : base(context)
        {
        }


        public PaymentVehicleDetailsViewModel GetPaymentWithDetails(int paymentId)
        {
            return base.GetList(p => p.Id == paymentId)
                .Select(p => p.ToDetailsViewModel())
                .FirstOrDefault();
        }

        public decimal CalculateTotalRevenue(DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = base.GetList()
                .Where(p => p.PaymentStatus == PaymentStatus.Completed);

            if (startDate.HasValue)
                query = query.Where(p => p.TransactionDateTime >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(p => p.TransactionDateTime <= endDate.Value);

            return query.Sum(p => p.Amount);
        }

       
        public IQueryable<PaymentVehicleDetailsViewModel> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return base.GetList().Select(b => b.ToDetailsViewModel());

            searchTerm = searchTerm.ToLower();

            return base.GetList()
                .Where(p =>
                    p.PaymentStatus.ToString().ToLower().Contains(searchTerm) ||
                    p.BookingVehicle.Client.User.UserName.ToLower().Contains(searchTerm) ||
                    p.BookingVehicle.Client.User.Email.ToLower().Contains(searchTerm) ||
                    p.Id.ToString().Contains(searchTerm)
                ).Select(b => b.ToDetailsViewModel());
        }
    }
}
