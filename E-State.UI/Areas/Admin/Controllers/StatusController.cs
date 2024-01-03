using E_State.Business.Abstract;
using E_State.Business.ValidationRules;
using E_State.Entities.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_State.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StatusController : Controller
    {
        ISituationService _situationService;

        public StatusController(ISituationService situationService)
        {
            _situationService = situationService;
        }

        public IActionResult Index()
        {
            var list = _situationService.List(x => x.Status == true);
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Situation situation)
        {
            SituationValidation validationRules = new SituationValidation();
            ValidationResult result = validationRules.Validate(situation);

            if (result.IsValid)
            {
                _situationService.Add(situation);
                TempData["Success"] = " Durum Ekleme İşlemi Başarı ile Gerçekleşti";
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
            var status = _situationService.GetById(id);
            _situationService.Delete(status);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var status = _situationService.GetById(id);
            return View(status);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Situation situation)
        {
            SituationValidation validationRules = new SituationValidation();
            ValidationResult result = validationRules.Validate(situation);

            if (result.IsValid)
            {
                _situationService.Update(situation);
                TempData["Update"] = " Durum Güncelleme İşlemi Başarı ile Gerçekleşti";
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


        public IActionResult FullDelete(int id)
        {
            var situationDelete = _situationService.GetById(id);
            _situationService.FullDelete(situationDelete);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSituationList()
        {
            var list = _situationService.List(x => x.Status == false).OrderBy(x => x.SituationId).ToList();
            return View(list);
        }

        public IActionResult GetActiveSituation(int id)
        {
            var IsActive = _situationService.GetById(id);
            _situationService.GetActive(IsActive);
            return RedirectToAction("Index");
        }

    }
}