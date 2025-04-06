using Dalel.ViewModels.Hotel_DTO;
using FluentValidation;

namespace Dalel.API.Vlidators
{

    public class ReviewHotelRoomDTOValidator : AbstractValidator<ReviewHotelRoomDTO>
    {
        public ReviewHotelRoomDTOValidator()
        {
            RuleFor(x => x.Comments).MaximumLength(500);
            RuleFor(x => x.Rating).InclusiveBetween(0, 5);
            RuleFor(x => x.ModificationDateTime).NotEmpty();
        }

    }
