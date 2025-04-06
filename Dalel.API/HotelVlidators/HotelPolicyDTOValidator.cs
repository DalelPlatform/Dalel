using Dalel.ViewModels.Hotel_DTO;
using FluentValidation;

namespace Dalel.API.Vlidators
{

    public class HotelPolicyDTOValidator : AbstractValidator<HotelPolicyDTO>
    {
        public HotelPolicyDTOValidator()
        {
            RuleFor(x => x.PolicyName).NotEmpty();
            RuleFor(x => x.HotelId).GreaterThan(0);
        }
    }
}
