using E_State.Entities.Entities;
using FluentValidation;

namespace E_State.Business.ValidationRules
{
    public class GeneralSettingsValidation : AbstractValidator<GeneralSettings>
    {
        public GeneralSettingsValidation()
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres alanı boş bırakılamaz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş bırakılamaz");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon numarası alanı boş bırakılamaz");
            RuleFor(x => x.ImageName).NotEmpty().WithMessage("Resim alanı boş bırakılamaz");
        }
    }
}
