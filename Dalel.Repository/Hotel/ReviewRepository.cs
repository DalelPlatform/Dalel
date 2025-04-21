// File: Dalel.Repository/ReviewHotelRoomRepository.cs
using System;
using System.Linq;
using System.Linq.Expressions;
using Dalel.ViewModels.Hotel;
using Models.Enums;
using Models.Hotel;
using Models;
using Dalel.ViewModels;

namespace Dalel.Repository
{
    public class ReviewHotelRoomRepository : BaseRepository<ReviewHotelRoom>
    {
        public ReviewHotelRoomRepository(DelelContext context) : base(context) { }

        /// <summary>
        /// Paged search by comments, rating range, date range, client, or booking.
        /// </summary>
        public PaginationViewModel<ReviewDetails> Search(
            string comments = null,
            float? minRating = null,
            float? maxRating = null,
            DateTime? from = null,
            DateTime? to = null,
            int? clientId = null,
            int? bookingId = null,
            bool descending = false,
            int pageSize = 5,
            int pageIndex = 1
        )
        {
            Expression<Func<ReviewHotelRoom, bool>> filter = r =>
                   (string.IsNullOrEmpty(comments) || r.Comments.Contains(comments))
                && (!minRating.HasValue || r.Rating >= minRating.Value)
                && (!maxRating.HasValue || r.Rating <= maxRating.Value)
                && (!from.HasValue || r.ReviewDate.Date >= from.Value.Date)
                && (!to.HasValue || r.ReviewDate.Date <= to.Value.Date)
                && (!clientId.HasValue || r.ClientId == clientId.Value)
                && (!bookingId.HasValue || r.BookingHotelRoomId == bookingId.Value);

            Expression<Func<ReviewHotelRoom, object>> orderBy = r => r.Id;

            return Search(
                filterPredicate: filter,
                orderBy: orderBy,
                selector: r => r.ToDetailsViewModel(),
                descending: descending,
                pageSize: pageSize,
                pageIndex: pageIndex
            );
        }

        // Single
        public ReviewDetails GetDetailsById(int id)
            => Table.Find(id)?.ToDetailsViewModel();

        // List as IQueryable
        public IQueryable<ReviewDetails> GetAllDetails()
            => Table.Select(r => r.ToDetailsViewModel());

        public IQueryable<ReviewDetails> GetByClient(int clientId)
            => Table
               .Where(r => r.ClientId == clientId)
               .Select(r => r.ToDetailsViewModel());

        public IQueryable<ReviewDetails> GetByBooking(int bookingId)
            => Table
               .Where(r => r.BookingHotelRoomId == bookingId)
               .Select(r => r.ToDetailsViewModel());


    }
}
