// File: Dalel.Repository/ReviewHotelRoomRepository.cs
using System.Linq.Expressions;
using Models.Hotel;
using Models;
using Dalel.ViewModels;

namespace Dalel.Repository
{
    public class ReviewHotelRoomRepository : BaseRepository<ReviewHotelRoom>
    {
        public ReviewHotelRoomRepository(DelelContext context) : base(context) { }
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
            => base.GetList(r => r.Id == id).FirstOrDefault().ToDetailsViewModel();

        // List as IQueryable
        public IQueryable<ReviewDetails> GetAllDetails()
            => base.GetList().Select(r => r.ToDetailsViewModel());

        public IQueryable<ReviewDetails> GetByClient(int clientId)
            => base.GetList(r => r.ClientId == clientId).Select(r => r.ToDetailsViewModel());

        public IQueryable<ReviewDetails> GetByBooking(int bookingId)
            => base.GetList(r => r.BookingHotelRoomId == bookingId)
            .Select(r => r.ToDetailsViewModel());
    }
}
