// File: Dalel.Repository/HotelRepository.cs
using System;
using System.Linq;
using System.Linq.Expressions;
using Dalel.ViewModels;
using Models.Enums;
using Models.Hotel;
using Models;

namespace Dalel.Repository
{
    public class HotelRepository : BaseRepository<Hotel>
    {
        public HotelRepository(DelelContext context) : base(context) { }

        public PaginationViewModel<HotelDetails> Search(
            string name = null,
            string city = null,
            string ownerId = null,
            VerificationStatus? status = null,
            bool includeDeleted = false,
            bool descending = false,
            int pageSize = 5,
            int pageIndex = 1)
        {
            Expression<Func<Hotel, bool>> filter = h =>
                (includeDeleted || !h.IsDeleted) &&
                (string.IsNullOrEmpty(name) || h.Name.Contains(name)) &&
                (string.IsNullOrEmpty(city) || h.City.Contains(city)) &&
                (string.IsNullOrEmpty(ownerId) || h.OwnerId == ownerId) &&
                (!status.HasValue || h.VerificationStatus == status);
            Expression<Func<Hotel, object>> orderBy = h => h.Name;
            return Search(filter, orderBy, h => h.ToDetailsViewModel(), descending, pageSize, pageIndex);
        }

        public HotelDetails GetDetailsById(int id) =>
            GetList(h => h.Id == id).Select(h => h.ToDetailsViewModel()).FirstOrDefault();

        public IQueryable<HotelDetails> GetAllDetails() =>
            GetList().Select(h => h.ToDetailsViewModel());

        public IQueryable<HotelDetails> GetByOwner(string ownerId) =>
            GetList(h => h.OwnerId == ownerId && !h.IsDeleted).Select(h => h.ToDetailsViewModel());
      
        public IQueryable<HotelDetails> GetPendingHotel()
        {
            return GetList(p => p.VerificationStatus == VerificationStatus.Pending)
                .Select(h => h.ToDetailsViewModel());

        }
        public bool UpdateHotelStatus(int HotelId, VerificationStatus newStatus)
        {
            var Hotel = base.GetList(h => h.Id == HotelId).FirstOrDefault();
            if (Hotel == null)
                return false;

            Hotel.VerificationStatus = newStatus;
            base.Update(Hotel);
            return true;
        }
    }
}
