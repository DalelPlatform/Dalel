using Dalel.ViewModels.Hotel_DTO;
using FluentValidation;

namespace Dalel.API.Vlidators
{

    public class ServiceDTOValidator : AbstractValidator<ServiceDTO>
    {
        public ServiceDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
