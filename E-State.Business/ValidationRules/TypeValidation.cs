using FluentValidation;

namespace E_State.Business.ValidationRules
{
    public class TypeValidation : AbstractValidator<Entities.Entities.Type>
    {
        public TypeValidation()
        {
            RuleFor(x => x.TypeName).NotEmpty().WithMessage("Tip adı boş bırakılamaz");
            RuleFor(x => x.SituationId).NotEmpty().WithMessage("Durum adı boş bırakılamaz");
        }
    }
}
