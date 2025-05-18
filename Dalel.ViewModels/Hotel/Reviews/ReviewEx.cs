using Models.Hotel;

namespace Dalel.ViewModels
{
    public static class ReviewEx
    {
        // Creation VM → Model
        public static ReviewHotelRoom ToModel(this ReviewCreation vm)
            => new ReviewHotelRoom
            {
                Comments = vm.Comments,
                Rating = vm.Rating,
                ReviewDate = vm.ReviewDate,
                BookingHotelRoomId = vm.BookingHotelRoomId,
                ClientId = vm.ClientId
            };

        // Update existing Model from VM
        public static void UpdateModel(this ReviewHotelRoom model, ReviewCreation vm)
        {
            model.Comments = vm.Comments;
            model.Rating = vm.Rating;
            model.ReviewDate = vm.ReviewDate;
            model.BookingHotelRoomId = vm.BookingHotelRoomId;
            model.ClientId = vm.ClientId;
        }

        // Model → Details VM
        public static ReviewDetails ToDetailsViewModel(this ReviewHotelRoom model)
            => new ReviewDetails
            {
                Id = model.Id,
                Comments = model.Comments,
                Rating = model.Rating,
                ReviewDate = model.ReviewDate,
                BookingHotelRoomId = model.BookingHotelRoomId,
                ClientId = model.ClientId
            };
    }
}
