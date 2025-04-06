using Dalel.ViewModels.Hotel_DTO;
using FluentValidation;

namespace Dalel.API.Vlidators
{

    public class HotelImageDTOValidator : AbstractValidator<HotelImageDTO>
    {
        public HotelImageDTOValidator()
        {
            RuleFor(x => x.Image).NotEmpty();
            RuleFor(x => x.HotelId).GreaterThan(0);
        }
    }
}
