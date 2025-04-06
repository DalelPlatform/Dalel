using Dalel.ViewModels.Hotel_DTO;
using FluentValidation;

namespace Dalel.API.Vlidators
{
    public class HotelServiceDTOValidator : AbstractValidator<HotelServiceDTO>
    {
        public HotelServiceDTOValidator()
        {
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            RuleFor(x => x.HotelId).GreaterThan(0);
            RuleFor(x => x.ServiceId).GreaterThan(0);
        }
    }
}
