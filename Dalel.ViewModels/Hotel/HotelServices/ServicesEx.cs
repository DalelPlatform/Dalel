using Models.Hotel;

namespace Dalel.ViewModels
{
    public static class ServicesEx
    {
        public static ServicesDetails ToDetailsViewModel(this HotelService hotelService)
        {
            return new ServicesDetails
            {
                Id = hotelService.Id,
                Price = hotelService.Price,
                HotelId = hotelService.HotelId,
                ServicesId = hotelService.ServicesId,
                ServiceName = hotelService.Service?.Name,
                ServiceDescription = hotelService.Service?.Description
            };
        }
    }
}
