using E_State.Business.Abstract;
using E_State.Business.ValidationRules;
using E_State.Entities.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace E_State.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TypeController : Controller
    {
        ITypeService _typeService;
        ISituationService _situationService;

        public TypeController(ITypeService typeService, ISituationService situationService)
        {
            _typeService = typeService;
            _situationService = situationService;
        }

        public IActionResult Index()
        {
            var list = _typeService.List();
            return View(list);
        }


        public IActionResult Create()
        {
            DropDown();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(E_State.Entities.Entities.Type type)
        {
            TypeValidation validationRules = new TypeValidation();
            ValidationResult result = validationRules.Validate(type);
            if (result.IsValid)
            {

                _typeService.Add(type);

                TempData["Success"] = " Tip Ekleme İşlemi Başarı ile Gerçekleşti";
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
            var delete = _typeService.GetById(id);
            _typeService.Delete(delete);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var type = _typeService.GetById(id);
            DropDown();
            return View(type);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(E_State.Entities.Entities.Type type)
        {
            TypeValidation validationRules = new TypeValidation();
            ValidationResult result = validationRules.Validate(type);
            if (result.IsValid)
            {

                _typeService.Update(type);

                TempData["Update"] = " Tip Güncelleme İşlemi Başarı ile Gerçekleşti";
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


        public IActionResult FullDelete(int id)
        {
            var typeDelete = _typeService.GetById(id);
            _typeService.FullDelete(typeDelete);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTypeList()
        {
            var list = _typeService.List(x => x.Status == false).ToList();
            return View(list);
        }

        public IActionResult GetActiveType(int id)
        {
            var IsActive = _typeService.GetById(id);
            _typeService.GetActive(IsActive);
            return RedirectToAction("Index");
        }





        public void DropDown()
        {
            List<SelectListItem> value = (from i in _situationService.List(x => x.Status == true).ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.SituationName,
                                              Value = i.SituationId.ToString()
                                          }).ToList();

            ViewBag.status = value;
        }
    }
}
