﻿using E_State.Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_State.Business.ValidationRules
{
    public class AdvertValidation : AbstractValidator<Advert>
    {
        public AdvertValidation()
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres bilgisi boş bırakılamaz");
            RuleFor(x => x.AdvertTitle).NotEmpty().WithMessage("İlan başlığı boş bırakılamaz");
            RuleFor(x => x.AdvertTitle).NotEmpty().MinimumLength(5).MaximumLength(500).WithMessage("Minumum 5 maksimum 500 karakter giriniz");

            RuleFor(x => x.Area).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.BathroomNumbers).NotEmpty().WithMessage("Banyo sayısı boş bırakılamaz");
            RuleFor(x => x.NumberOfRooms).NotEmpty().WithMessage("Oda sayısı boş bırakılamaz");
            RuleFor(x => x.Descriptions).NotEmpty().WithMessage("Açıklama alanı boş bırakılamaz");
            RuleFor(x => x.Floor).NotEmpty().WithMessage("Kat sayısı boş bırakılamaz");
            RuleFor(x => x.Garage).NotEmpty().WithMessage("Garaj alanı boş bırakılamaz");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat bilgisi boş bırakılamaz");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon alanı boş bırakılamaz");
            RuleFor(x => x.NeighbourhoodId).NotEmpty().WithMessage("Mahalle alanı boş bırakılamaz");
            RuleFor(x => x.DistrictId).NotEmpty().WithMessage("Semt alanı boş bırakılamaz");
            RuleFor(x => x.TypeId).NotEmpty().WithMessage("Tip alanı boş bırakılamaz");
            RuleFor(x => x.CityId).NotEmpty().WithMessage("Şehir alanı boş bırakılamaz");
            RuleFor(x => x.SituationId).NotEmpty().WithMessage("Durum alanı boş bırakılamaz");
            //RuleFor(x => x.PhoneNumber).Matches(new Regex(@"([\+]90?)([ ]?)(\([0-9]{3}\))([ ]?)([0-9]{3})(\s*[\-]?)([0-9]{2})(\s*[\-]?)([0-9]{2})"));
        }
    }
}
