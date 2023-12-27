using E_State.Entities.Entities;
using FluentValidation;

namespace E_State.Business.ValidationRules
{
    public class ImagesValidation : AbstractValidator<Images>
    {
        public ImagesValidation()
        {
            RuleFor(x => x.ImageName).NotEmpty().WithMessage("Resim alanı boş bırakılamaz");
            RuleFor(x => x.AdvertId).NotEmpty().WithMessage("İlan alanı boş bırakılamaz");
        }
    }
}
