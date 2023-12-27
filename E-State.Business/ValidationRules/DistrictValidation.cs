using E_State.Entities.Entities;
using FluentValidation;

namespace E_State.Business.ValidationRules
{
    public class DistrictValidation : AbstractValidator<District>
    {
        public DistrictValidation()
        {
            RuleFor(x => x.DistrictName).NotEmpty().WithMessage("Semt adı boş bırakılamaz");
            RuleFor(x => x.CityKey).NotEmpty().WithMessage("Şehir alanı boş bırakılamaz");
        }
    }
}
