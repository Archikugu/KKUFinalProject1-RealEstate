using E_State.Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_State.Business.ValidationRules
{
    public class CityValidation : AbstractValidator<City>
    {
        public CityValidation()
        {
            RuleFor(x => x.CityName).NotEmpty().WithMessage("Şehir ismi boş bırakılamaz");
            RuleFor(x => x.CityName).MinimumLength(3).MaximumLength(20).WithMessage("Minumum 3 karakter ve En fazla 20 karakter giriniz");
        }
    }
}
