using E_State.Business.Abstract;
using E_State.Business.ValidationRules;
using E_State.DataAccess.Abstract;
using E_State.Entities.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace E_State.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DistrictController : Controller
    {
        IDistrictService _districtService;
        ICityService _cityService;

        public DistrictController(IDistrictService districtService, ICityService cityService)
        {
            _districtService = districtService;
            _cityService = cityService;
        }

        public IActionResult Index(int page = 1)
        {
            var list = _districtService.List(x => x.Status == true).OrderBy(x => x.DistrictId).ToList().ToPagedList(page, 50);

            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            DropDown();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(District district)
        {
            DistrictValidation validationRules = new DistrictValidation();
            ValidationResult result = validationRules.Validate(district);
            if (result.IsValid)
            {

                _districtService.Add(district);

                TempData["Success"] = " Semt Ekleme İşlemi Başarı ile Gerçekleşti";
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            DropDown();
            return View();
        }


        public IActionResult Delete(int id)
        {
            var district = _districtService.GetById(id);
            _districtService.Delete(district);
            return RedirectToAction("Index");
        }

        public IActionResult FullDelete(int id)
        {
            var districtDelete = _districtService.GetById(id);
            _districtService.FullDelete(districtDelete);
            return RedirectToAction("Index");
        }

        public IActionResult GetActiveDistrict(int id)
        {
            var IsActive = _districtService.GetById(id);
            _districtService.GetActive(IsActive);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteDistrictList(int page = 1)
        {
            var list = _districtService.List(x => x.Status == false).OrderBy(x => x.DistrictId).ToList().ToPagedList(page, 50);
            return View(list);
        }

        public IActionResult Update(int id)
        {
            DropDown();
            var update = _districtService.GetById(id);
            return View(update);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(District district)
        {
            DistrictValidation validationRules = new DistrictValidation();
            ValidationResult result = validationRules.Validate(district);
            if (result.IsValid)
            {
                _districtService.Update(district);
                TempData["Update"] = " Semt Güncelleme İşlemi Başarı ile Gerçekleşti";
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(district);
        }

        public void DropDown()
        {
            List<SelectListItem> value = (from i in _cityService.List(x => x.Status == true).ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.CityName,
                                              Value = i.CityId.ToString()
                                          }).ToList();

            ViewBag.cities = value;
        }
    }
}
