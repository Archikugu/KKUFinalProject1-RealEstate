using E_State.Entities.Entities;
using FluentValidation;

namespace E_State.Business.ValidationRules
{
    public class NeighbourhoodValidation : AbstractValidator<Neighbourhood>
    {
        public NeighbourhoodValidation()
        {
            RuleFor(x => x.NeighbourhoodName).NotEmpty().WithMessage("Mahalle adı boş bırakılamaz");
            RuleFor(x => x.DistrictKey).NotEmpty().WithMessage("Semt adı boş bırakılamaz");
        }
    }
}
