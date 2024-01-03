using E_State.Business.Abstract;
using E_State.Business.ValidationRules;
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
    public class NeighbourhoodController : Controller
    {
        INeighbourhoodService _neighbourhoodService;
        IDistrictService _districtService;

        public NeighbourhoodController(INeighbourhoodService neighbourhoodService, IDistrictService districtService)
        {
            _neighbourhoodService = neighbourhoodService;
            _districtService = districtService;
        }

        public IActionResult Index(int page = 1)
        {
            var list = _neighbourhoodService.List(x => x.Status == true).OrderBy(x => x.NeighbourhoodId).ToList().ToPagedList(page, 500);
            return View(list);
        }

        public IActionResult Create()
        {
            Dropdown();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Neighbourhood neighbourhood)
        {
            NeighbourhoodValidation validationRules = new NeighbourhoodValidation();
            ValidationResult result = validationRules.Validate(neighbourhood);
            if (result.IsValid)
            {

                _neighbourhoodService.Add(neighbourhood);

                TempData["Success"] = " Mahalle Ekleme İşlemi Başarı ile Gerçekleşti";
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            Dropdown();
            return View();
        }

        public void Dropdown()
        {
            List<SelectListItem> value = (from i in _districtService.List(x => x.Status == true).ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.DistrictName,
                                              Value = i.DistrictId.ToString(),
                                          }).ToList();
            ViewBag.district = value;
        }


        public IActionResult Delete(int id)
        {
            var neigh = _neighbourhoodService.GetById(id);
            _neighbourhoodService.Delete(neigh);
            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            Dropdown();
            var neigh = _neighbourhoodService.GetById(id);
            return View(neigh);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Neighbourhood neighbourhood)
        {
            NeighbourhoodValidation validationRules = new NeighbourhoodValidation();
            ValidationResult result = validationRules.Validate(neighbourhood);
            if (result.IsValid)
            {
                _neighbourhoodService.Update(neighbourhood);
                TempData["Update"] = " Mahalle Güncelleme İşlemi Başarı ile Gerçekleşti";
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(neighbourhood);
        }


        public IActionResult DeleteNeighbourhoodList(int page = 1)
        {
            var list = _neighbourhoodService.List(x => x.Status == false).OrderBy(x => x.NeighbourhoodId).ToList().ToPagedList(page, 50);
            return View(list);
        }


        public IActionResult GetActiveNeighbourhood(int id)
        {
            var IsActive = _neighbourhoodService.GetById(id);
            _neighbourhoodService.GetActive(IsActive);
            return RedirectToAction("Index");
        }


        public IActionResult FullDelete(int id)
        {
            var neighDelete = _neighbourhoodService.GetById(id);
            _neighbourhoodService.FullDelete(neighDelete);
            return RedirectToAction("Index");
        }

    }
}
