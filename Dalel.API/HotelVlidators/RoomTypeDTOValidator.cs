using Dalel.ViewModels.Hotel_DTO;
using FluentValidation;

namespace Dalel.Validations.Hotel
{
    public class RoomTypeDTOValidator : AbstractValidator<RoomTypeDTO>
    {
        public RoomTypeDTOValidator()
        {
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Room type is required")
                .IsInEnum().WithMessage("Invalid room type");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");

            RuleFor(x => x.NumberOfRooms)
                .GreaterThan(0).WithMessage("Number of rooms must be positive");

            RuleFor(x => x.NumberOfBeds)
                .GreaterThan(0).WithMessage("Number of beds must be positive");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be positive");

            RuleForEach(x => x.Rooms)
                .SetValidator(new RoomDTOValidator());
        }
    }
}