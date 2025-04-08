using Dalel.ViewModels.Hotel_DTO;
using FluentValidation;

namespace Dalel.API.Vlidators
{
    public class BookingHotelRoomDTOValidator : AbstractValidator<BookingHotelRoomDTO>
    {
        public BookingHotelRoomDTOValidator()
        {
            RuleFor(x => x.Checkin).LessThan(x => x.Checkout);
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            RuleFor(x => x.NumberOfGuests).GreaterThan(0);
            RuleFor(x => x.BookingStatus).NotEmpty();
            RuleFor(x => x.ClientId).NotEmpty();
            RuleFor(x => x.RoomId).GreaterThan(0);
        }
    }
}
