using Dalel.ViewModels.Hotel_DTO;
using FluentValidation;

namespace Dalel.API.Vlidators
{
    public class RoomTypeDTOValidator : AbstractValidator<RoomTypeDTO>
    {
        public RoomTypeDTOValidator()
        {
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.NumberOfRooms).GreaterThan(0);
            RuleFor(x => x.NumberOfBeds).GreaterThan(0);
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
        }
    }
}
