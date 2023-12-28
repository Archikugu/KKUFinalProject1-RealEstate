using E_State.Entities.Entities;
using FluentValidation;

namespace E_State.Business.ValidationRules
{
    public class ImagesValidation : AbstractValidator<Images>
    {
        public ImagesValidation()
        {
            RuleFor(x => x.Image).NotEmpty().WithMessage("Resim alanı boş bırakılamaz");
        }
    }
}
