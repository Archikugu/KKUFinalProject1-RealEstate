using E_State.Business.Abstract;
using E_State.Business.ValidationRules;
using E_State.Entities.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace E_State.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class CityController : Controller
    {
        ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        public IActionResult Index(int page = 1)
        {
            var list = _cityService.List(x => x.Status == true).OrderBy(x => x.CityKey).ToList().ToPagedList(page, 30);
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(City city)
        {
            CityValidation validationRules = new CityValidation();
            ValidationResult result = validationRules.Validate(city);
            if (result.IsValid)
            {
                _cityService.Add(city);
                TempData["Success"] = " Şehir Ekleme İşlemi Başarı ile Gerçekleşti";
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var cityDelete = _cityService.GetById(id);
            _cityService.Delete(cityDelete);
            return RedirectToAction("Index");
        }


        public IActionResult FullDelete(int id)
        {
            var cityDelete = _cityService.GetById(id);
            _cityService.FullDelete(cityDelete);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCityList(int page = 1)
        {
            var list = _cityService.List(x => x.Status == false).OrderBy(x => x.CityKey).ToList().ToPagedList(page, 30);
            return View(list);
        }

        public IActionResult GetActiveCity(int id)
        {
            var IsActive = _cityService.GetById(id);
            _cityService.GetActive(IsActive);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var updateCity = _cityService.GetById(id);
            return View(updateCity);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(City city)
        {
            CityValidation validationRules = new CityValidation();
            ValidationResult result = validationRules.Validate(city);
            if (result.IsValid)
            {
                _cityService.Update(city);
                TempData["Update"] = " Şehir Güncelleme İşlemi Başarı ile Gerçekleşti";
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(city);
        }
    }
}
