using Dalel.ViewModels.Hotel_DTO;
using FluentValidation;

namespace Dalel.Validations.Hotel
{
    public class ReviewHotelRoomDTOValidator : AbstractValidator<ReviewHotelRoomDTO>
    {
        public ReviewHotelRoomDTOValidator()
        {
            RuleFor(x => x.Comments)
                .MaximumLength(1000).WithMessage("Comments cannot exceed 1000 characters");

            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5");

            RuleFor(x => x.ReviewDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Modification date cannot be in the future");
        }
    }
}