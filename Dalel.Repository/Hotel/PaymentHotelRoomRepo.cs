// File: Dalel.Repository/PaymentHotelRoomRepository.cs
using System;
using System.Linq;
using System.Linq.Expressions;
using Dalel.ViewModels;
using Models.Enums;
using Models.Hotel;
using Models;

namespace Dalel.Repository
{
    public class PaymentHotelRoomRepository : BaseRepository<PaymentHotelRoom>
    {
        public PaymentHotelRoomRepository(DelelContext context) : base(context) { }

        public PaginationViewModel<HotelPaymentDetails> Search(
            decimal? minAmount = null,
            decimal? maxAmount = null,
            PaymentMethod? method = null,
            PaymentStatus? status = null,
            string clientId = null,
            int? hotelId = null,
            bool descending = false,
            int pageSize = 5,
            int pageIndex = 1)
        {
            Expression<Func<PaymentHotelRoom, bool>> filter = p =>
                (!minAmount.HasValue || p.AmountPaid >= minAmount) &&
                (!maxAmount.HasValue || p.AmountPaid <= maxAmount) &&
                (!method.HasValue || p.PaymentMethod == method) &&
                (!status.HasValue || p.PaymentStatus == status) &&
                (string.IsNullOrEmpty(clientId) || p.ClientId.ToString() == clientId) &&
                (!hotelId.HasValue || p.HotelId == hotelId);
            Expression<Func<PaymentHotelRoom, object>> orderBy = p => p.Id;
            return Search(filter, orderBy, p => p.ToDetailsViewModel(), descending, pageSize, pageIndex);
        }

        public HotelPaymentDetails GetDetailsById(int id) =>
            GetList(p => p.Id == id).Select(p => p.ToDetailsViewModel()).FirstOrDefault();

        public IQueryable<HotelPaymentDetails> GetAllDetails() =>
            GetList().Select(p => p.ToDetailsViewModel());

        public IQueryable<HotelPaymentDetails> GetByBooking(int bookingId) =>
            GetList(p => p.BookingHotelRoomId == bookingId).Select(p => p.ToDetailsViewModel());

        public IQueryable<HotelPaymentDetails> GetByClient(string clientId) =>
            GetList(p => p.ClientId.ToString() == clientId).Select(p => p.ToDetailsViewModel());

        public IQueryable<HotelPaymentDetails> GetByHotel(int hotelId) =>
            GetList(p => p.HotelId == hotelId).Select(p => p.ToDetailsViewModel());
    }
}
