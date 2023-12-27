using E_State.Entities.Entities;
using FluentValidation;

namespace E_State.Business.ValidationRules
{
    public class SituationValidation : AbstractValidator<Situation>
    {
        public SituationValidation()
        {
            RuleFor(x => x.SituationName).NotEmpty().WithMessage("Durum alanı boş bırakılamaz");
        }
    }
}
