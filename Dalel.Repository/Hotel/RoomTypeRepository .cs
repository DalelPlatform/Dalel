// File: Dalel.Repository/RoomTypeRepository.cs
using System;
using System.Linq;
using System.Linq.Expressions;
using Dalel.ViewModels;
using Models.Enums;
using Models.Hotel;
using Models;

namespace Dalel.Repository
{
    public class RoomTypeRepository : BaseRepository<RoomType>
    {
        public RoomTypeRepository(DelelContext context) : base(context) { }

        public PaginationViewModel<RoomTypeDetails> Search(
            HotelRoomType? type = null,
            int? maxOccupancy = null,
            bool? hasBreakfast = null,
            float? minPrice = null,
            float? maxPrice = null,
            int? hotelId = null,
            bool descending = false,
            int pageSize = 5,
            int pageIndex = 1)
        {
            Expression<Func<RoomType, bool>> filter = rt =>
                (!type.HasValue || rt.Type == type) &&
                (!maxOccupancy.HasValue || rt.MaxOccupancy == maxOccupancy) &&
                (!hasBreakfast.HasValue || rt.HasBreakfast == hasBreakfast) &&
                (!minPrice.HasValue || rt.Price >= minPrice) &&
                (!maxPrice.HasValue || rt.Price <= maxPrice) &&
                (!hotelId.HasValue || rt.HotelId == hotelId);
            Expression<Func<RoomType, object>> orderBy = rt => rt.Id;
            return Search(filter, orderBy, rt => rt.ToDetailsViewModel(), descending, pageSize, pageIndex);
        }

        public RoomTypeDetails GetDetailsById(int id) =>
            GetList(rt => rt.Id == id).Select(rt => rt.ToDetailsViewModel()).FirstOrDefault();

        public IQueryable<RoomTypeDetails> GetAllDetails() =>
            GetList().Select(rt => rt.ToDetailsViewModel());

        public IQueryable<RoomTypeDetails> GetByHotel(int hotelId) =>
            GetList(rt => rt.HotelId == hotelId).Select(rt => rt.ToDetailsViewModel());
    }
}
