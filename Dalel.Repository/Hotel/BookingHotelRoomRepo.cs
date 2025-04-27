// File: Dalel.Repository/BookingHotelRoomRepository.cs
using System;
using System.Linq;
using System.Linq.Expressions;
using Dalel.ViewModels;
using Models.Enums;
using Models.Hotel;
using Models;

namespace Dalel.Repository
{
    public class BookingHotelRoomRepository : BaseRepository<BookingHotelRoom>
    {
        public BookingHotelRoomRepository(DelelContext context) : base(context) { }

        public PaginationViewModel<BookingHotelRoomDetails> Search(
            DateTime? checkin = null,
            DateTime? checkout = null,
            string clientId = null,
            BookingStatus? status = null,
            int? roomId = null,
            bool descending = false,
            int pageSize = 5,
            int pageIndex = 1)
        {
            Expression<Func<BookingHotelRoom, bool>> filter = b =>
                (!checkin.HasValue || b.Checkin.Date >= checkin.Value.Date) &&
                (!checkout.HasValue || b.Checkout.Date <= checkout.Value.Date) &&
                (string.IsNullOrEmpty(clientId) || b.ClientId == clientId) &&
                (!status.HasValue || b.BookingStatus == status) &&
                (!roomId.HasValue || b.RoomId == roomId);
            Expression<Func<BookingHotelRoom, object>> orderBy = b => b.Id;
            return Search(filter, orderBy, b => b.ToDetailsViewModel(), descending, pageSize, pageIndex);
        }

        public BookingHotelRoomDetails GetDetailsById(int id) =>
            GetList(b => b.Id == id).Select(b => b.ToDetailsViewModel()).FirstOrDefault();

        public IQueryable<BookingHotelRoomDetails> GetAllDetails() =>
            GetList().Select(b => b.ToDetailsViewModel());

        public IQueryable<BookingHotelRoomDetails> GetByClient(string clientId) =>
            GetList(b => b.ClientId == clientId).Select(b => b.ToDetailsViewModel());

        public IQueryable<BookingHotelRoomDetails> GetByRoom(int roomId) =>
            GetList(b => b.RoomId == roomId).Select(b => b.ToDetailsViewModel());
        public IQueryable<BookingHotelRoomDetails> GetPendingBooking()
        {
            return GetList(p => p.BookingStatus == BookingStatus.Panding).
                Select(book => book.ToDetailsViewModel());
        }
        public void UpdateBookingStatus(int Book_Id, BookingStatus newStatus)
        {
            var Booking = GetList(res => res.Id == Book_Id).FirstOrDefault();
            if (Booking != null)
            {
                Booking.BookingStatus = newStatus;
                Update(Booking);
            }
        }
    }
}
