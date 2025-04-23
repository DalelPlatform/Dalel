// File: Dalel.Repository/RoomRepository.cs
using System;
using System.Linq;
using System.Linq.Expressions;
using Models.Enums;
using Models.Hotel;
using Models;
using Dalel.ViewModels;

namespace Dalel.Repository
{
    public class RoomRepository : BaseRepository<Room>
    {
        public RoomRepository(DelelContext context) : base(context) { }

        public PaginationViewModel<RoomDetails> Search(
            int? roomTypeId = null,
            string viewType = null,
            AvaliabilityStatus? availability = null,
            bool descending = false,
            int pageSize = 5,
            int pageIndex = 1)
        {
            Expression<Func<Room, bool>> filter = r =>
                (!roomTypeId.HasValue || r.RoomTypeId == roomTypeId) &&
                (string.IsNullOrEmpty(viewType) || r.ViewType.Contains(viewType)) &&
                (!availability.HasValue || r.Availability == availability);
            Expression<Func<Room, object>> orderBy = r => r.Id;
            return Search(filter, orderBy, r => r.ToDetailsViewModel(), descending, pageSize, pageIndex);
        }

        public RoomDetails GetDetailsById(int id) =>
            GetList(r => r.Id == id).Select(r => r.ToDetailsViewModel()).FirstOrDefault();

        public IQueryable<RoomDetails> GetAllDetails() =>
            GetList().Select(r => r.ToDetailsViewModel());

        public IQueryable<RoomDetails> GetByAvailability(AvaliabilityStatus availability) =>
            GetList(r => r.Availability == availability).Select(r => r.ToDetailsViewModel());

        public IQueryable<RoomDetails> GetByRoomType(int roomTypeId) =>
            GetList(r => r.RoomTypeId == roomTypeId).Select(r => r.ToDetailsViewModel());
    }
}
